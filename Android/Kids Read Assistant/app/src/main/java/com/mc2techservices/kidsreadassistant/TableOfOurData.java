package com.mc2techservices.kidsreadassistant;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.mc2techservices.kidsreadassistant.supportcode.AppSpecific;
import com.mc2techservices.kidsreadassistant.supportcode.FetchData;
import com.mc2techservices.kidsreadassistant.supportcode.FetchDataCallbackInterface;
import com.mc2techservices.kidsreadassistant.supportcode.GeneralFunctions01;

public class TableOfOurData extends Activity implements FetchDataCallbackInterface {
    CheckBox chkK;
    CheckBox chkFirst;
    CheckBox chkSecond;
    CheckBox chkThird;
    CheckBox chkFourth;
    CheckBox chkFifth;
    CheckBox chkStories;
    CheckBox chkOther;
    CheckBox chkWordLists;
    LinearLayout llODEntries;
    ProgressBar progressBar2;
    String pAllData;
    @Override
    public void fetchDataCallback(String caller, String result) {
        Log.d("fetchDataCallback", caller + " came back with " + result);
        if (result==null) return;
        if (caller.equals("GetOurContent"))
        {
            progressBar2.setVisibility(View.GONE);
            if (result.length()==0)  //
            {
                GeneralFunctions01.Oth.Alert(this, "Sorry, we couldn't get this info right now, try again in a bit.");
            }
            else
            {
                pAllData=result;
                ParseOurData(result);
            }
        }
    }
    private void ConfigCheckboxes()
    {
        chkFirst = findViewById (R.id.chkFirst);
        chkSecond = findViewById (R.id.chkSecond);
        chkThird = findViewById (R.id.chkThird);
        chkFourth = findViewById (R.id.chkFourth);
        chkFifth = findViewById (R.id.chkFifth);
        chkStories = findViewById (R.id.chkStories);
        chkOther = findViewById (R.id.chkOther);
        chkWordLists= findViewById (R.id.chkWordLists);
        chkK = findViewById (R.id.chkK);
        chkK.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGradeK", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGradeK", "false");
                }
                GetOurData();
            }
        });

        chkFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGrade1", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGrade1", "false");
                }
                GetOurData();
            }
        });
        chkSecond.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGrade2", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGrade2", "false");
                }
                GetOurData();
            }
        });
        chkThird.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGrade3", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGrade3", "false");

                }
                GetOurData();
            }
        });
        chkFourth.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGrade4", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGrade4", "false");
                }
                GetOurData();
            }
        });
        chkFifth.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterGrade5", "true");
                }
                else
                {
                    ChangeDCFilter("FilterGrade5", "false");
                }
                GetOurData();
            }
        });
        chkStories.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterStories", "true");
                }
                else
                {
                    ChangeDCFilter("FilterStories", "false");
                }
                GetOurData();
            }
        });
        chkWordLists.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterWordLists", "true");
                }
                else
                {
                    ChangeDCFilter("FilterWordLists", "false");
                }
                GetOurData();
            }
        });
        chkOther.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (((CheckBox) v).isChecked()) {
                    ChangeDCFilter("FilterOther", "true");
                }
                else
                {
                    ChangeDCFilter("FilterOther", "false");
                }
                GetOurData();
            }
        });
    }

    private void AlertAboutNoData() {

        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case DialogInterface.BUTTON_POSITIVE:
                        finish();
                }
            }
        };
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("We couldn't get our data right now; try again later.").setPositiveButton("OK", dialogClickListener).show();
    }

    private void ParseOurData(String pOurData)
    {
        llODEntries.removeAllViews();
        boolean empty=true;
        String[] lines=pOurData.split("l#d");
        for (int i = 0; i < lines.length; i++) {
            String[] vals=lines[i].split("p#d");
            //UD_ID integer primary key, UD_NameOfEntry text, UD_Category text, UD_Words
            String pNameOfEntry=GeneralFunctions01.Text.GetValInArray(vals, 0);
            String pCategory=GeneralFunctions01.Text.GetValInArray(vals, 1);
            String pAllData=GeneralFunctions01.Text.GetValInArray(vals, 2);
            String pGradeLevel=GeneralFunctions01.Text.GetValInArray(vals, 3);
            boolean pBuildIt=DoWeBuildTableRow(pCategory,pGradeLevel);
            if (pBuildIt)
            {
                LinearLayout bhrow = BuildTableRow(pNameOfEntry, pAllData, pCategory, pGradeLevel);
                llODEntries.addView(bhrow);
            }
            empty = false;
        }
        if (empty == true) {
            AlertAboutNoData();
        }
        else
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"OurDataDLDate",GeneralFunctions01.Dte.GetCurrentDate());
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"OurDataDLContent",pOurData);
        }
    }

    private boolean DoWeBuildTableRow(String pCategory, String pGrade)
    {
        if (pCategory.equals("Story"))
        {
            if (!chkStories.isChecked()) return false;
        }
        else if (pCategory.equals("Word List"))
        {
            if (!chkWordLists.isChecked()) return false;
        }
        else if (pCategory.equals("Other"))
        {
            if (!chkOther.isChecked()) return false;
        }
        else
        {
            return false;  //It's not a valid category
        }

        if (pGrade.equals("K"))
        {
            if (!chkK.isChecked()) return false;
        }
        if (pGrade.equals("1"))
        {
            if (!chkFirst.isChecked()) return false;
        }
        if (pGrade.equals("2"))
        {
            if (!chkSecond.isChecked()) return false;
        }
        if (pGrade.equals("3"))
        {
            if (!chkThird.isChecked()) return false;
        }
        if (pGrade.equals("4"))
        {
            if (!chkFourth.isChecked()) return false;
        }
        if (pGrade.equals("5"))
        {
            if (!chkFifth.isChecked()) return false;
        }

        return true;
    }
    /*
    private void ModUserContent()
    {
        Intent intent = new Intent(this, AddModDel.class);
        intent.putExtra("FullTextIn", "");
        intent.putExtra("IDIn", "-1");
        startActivity(intent);
    }
    */
    private LinearLayout BuildTableRow(String pNameIn, String pFullDataIn, String pCategoryIn, String pGradeIn)
    {
        LinearLayout row = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.cell_pm_dlcontent, null);
        ((TextView)row.findViewById(R.id.textViewCUDTitle)).setText(pNameIn);
        (row.findViewById(R.id.textViewCUDTitle)).setTag(pFullDataIn);
        ((TextView)row.findViewById(R.id.textViewCUDCategory)).setText("Category: " + pCategoryIn);
        String[] pWords=pFullDataIn.split(" ");
        ((TextView)row.findViewById(R.id.textViewCUDWords)).setText("Words: " + pWords.length);
        ((TextView)row.findViewById(R.id.textViewCUDGradeLevel)).setText(pGradeIn);

        row.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TextView txtCellName=v.findViewById(R.id.textViewCUDTitle);
                TextView txtCellCategory=v.findViewById(R.id.textViewCUDCategory);
                TextView txtCellGrade=v.findViewById(R.id.textViewCUDGradeLevel);
                String pNameIn=txtCellName.getText().toString();
                String pFullDataIn=txtCellName.getTag().toString();
                String pCategoryIn=txtCellCategory.getText().toString();
                String pGradeIn=txtCellGrade.getText().toString();
                GoToAddModDel(pNameIn,pFullDataIn,pCategoryIn,pGradeIn);
            }
        });
        return row;
    }
    private void GoToAddModDel(String pNameIn, String pFullDataIn, String pCategoryIn, String pGradeIn)
    {
        Intent intent = new Intent(this, AddModDel.class);
        intent.putExtra("FullTextIn", pFullDataIn);
        intent.putExtra("CategoryIn", pCategoryIn);
        intent.putExtra("NameIn", pNameIn);
        intent.putExtra("GradeIn", pGradeIn);
        intent.putExtra("EntryPoint", "DLArea");
        intent.putExtra("IDIn", "-1");
        startActivity(intent);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_table_of_our_data);
        llODEntries=findViewById(R.id.llODEntries);
        progressBar2=findViewById(R.id.progressBar2);
        ConfigCheckboxes();
        SetDCFilters();
        GetOurData();

    }
    private void SetDCFilters()
    {
        String pTempVal;
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGradeK");
        chkK.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGrade1");
        chkFirst.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGrade2");
        chkSecond.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGrade3");
        chkThird.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGrade4");
        chkFourth.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterGrade5");
        chkFifth.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterStories");
        chkStories.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterWordLists");
        chkWordLists.setChecked(Boolean.parseBoolean(pTempVal));
        pTempVal = GeneralFunctions01.Cfg.ReadSharedPreference(this, "FilterOther");
        chkOther.setChecked(Boolean.parseBoolean(pTempVal));
    }
    private void ChangeDCFilter(String pDSFilter, String pYorN)
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,pDSFilter,pYorN);
    }
    private void GetOurData() {
        String pDate=GeneralFunctions01.Cfg.ReadSharedPreference(this,"OurDataDLDate");
        //pDate="";  //test
        if (pDate.equals("")) pDate="2000-01-01";
        long pDaysFromLastDL=GeneralFunctions01.Dte.DaysBetweenDate(pDate,GeneralFunctions01.Dte.GetCurrentDate());
        if (pDaysFromLastDL>7)
        {
            if (pAllData==null){
                String pURL = AppSpecific.gloWebServiceURL + "/GetOurContent";
                EditText txtGetData=findViewById(R.id.txtGetData);
                String pParams = "";
                progressBar2.setVisibility(View.VISIBLE);
                new FetchData("GetOurContent", pURL, pParams, AppSpecific.gloxmlns,  5, this).execute();
            }
            else
            {
                ParseOurData(pAllData);
            }
        }
        else
        {
            String pAllData=GeneralFunctions01.Cfg.ReadSharedPreference(this,"OurDataDLContent");
            ParseOurData(pAllData);
        }

    }

}
