package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.DBAdapter;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

public class TableOfUserDataMD extends Activity {
    TextView txtNoUserDataEntries;
    LinearLayout llUserDataEntries;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_table_of_user_data_amd);
        Initialize();
        Initialize2();
    }
    public void onResume () {
        super.onResume();
        Initialize2();

    }
    private void Initialize()
    {
        txtNoUserDataEntries=findViewById(R.id.txtNoUserDataEntries);
        llUserDataEntries=findViewById(R.id.llUserDataEntries);
    }
    private void Initialize2()
    {
        llUserDataEntries.removeAllViews();
        PopulateTableEntries("SELECT * FROM tblUserDefined;");
    }
    //pNameOfEntry, pID, pCategory,pGrade
    private LinearLayout BuildTableRow(String pNameIn, String pIDIn, String pCategoryIn, String pGradeIn)
    {
        LinearLayout row = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.cell_pm_dlcontent, null);
        ((TextView)row.findViewById(R.id.textViewCUDTitle)).setText(pNameIn);
        (row.findViewById(R.id.textViewCUDTitle)).setTag(pIDIn);
        ((TextView)row.findViewById(R.id.textViewCUDCategory)).setText("Category: " + pCategoryIn);
        ((TextView)row.findViewById(R.id.textViewCUDWords)).setText("");
        ((TextView)row.findViewById(R.id.textViewCUDGradeLevel)).setText(pGradeIn);
        row.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TextView txtCellName=v.findViewById(R.id.textViewCUDTitle);
                String pID=txtCellName.getTag().toString();
                GoToAddModDel(pID);
            }
        });
        return row;
    }


    private void PopulateTableEntries(String pSQLIn) {
        llUserDataEntries.removeAllViews();
        boolean empty = true;
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        String AllBHData=myDb.getAllRowsAsString(pSQLIn);
        myDb.close();
        if (AllBHData.equals(null)) return;
        String[] lines=AllBHData.split("l#d");
        for (int i = 0; i < lines.length; i++) {
            if (AllBHData.equals("")) break;
            String[] vals=lines[i].split("p#d");
            //UD_ID integer primary key, UD_NameOfEntry text, UD_Category text, UD_Words
            String pID= GeneralFunctions01.Text.GetValInArray(vals, 0);
            String pNameOfEntry=GeneralFunctions01.Text.GetValInArray(vals, 1);
            String pCategory=GeneralFunctions01.Text.GetValInArray(vals, 2);
            String pGrade=GeneralFunctions01.Text.GetValInArray(vals, 4);
            LinearLayout bhrow = BuildTableRow(pNameOfEntry, pID, pCategory,pGrade);
            llUserDataEntries.addView(bhrow);
            empty = false;
        }
        if (empty == true) {
            llUserDataEntries.addView(txtNoUserDataEntries);
        }
    }
    private void GoToAddModDel(String pID)
    {
        Intent intent = new Intent(this, AddModDel.class);
        intent.putExtra("FullTextIn", "");
        intent.putExtra("CategoryIn", "");
        intent.putExtra("NameIn", "");
        intent.putExtra("GradeIn", "");
        intent.putExtra("IDIn", pID);
        startActivity(intent);
    }


}
