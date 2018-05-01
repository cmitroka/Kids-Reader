package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.AppSpecific;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.DBAdapter;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

import java.util.Timer;

public class AddModDel extends Activity {
    EditText txtName;
    Spinner ddCategory;
    Spinner ddGrade;
    EditText txtFullText;
    String IDIn;
    Timer wc1Tmr;
    String EntryPoint;
    String[] pCategoryList = new String[] { " ", "Word List","Story","Other" };
    String[] pGradeList = new String[] { " ", "K","1","2","3","4","5" };
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_mod_del);
        Initialize();
    }
    private void WriteSharedPreference(String pKey, String pValue)
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,pKey,pValue);
    }

    private void Initialize()
    {
        txtName=findViewById(R.id.txtName);
        ddCategory=findViewById(R.id.ddCategory);
        txtFullText=findViewById(R.id.txtFullText);
        ddGrade=findViewById(R.id.ddGrade);
        String tempTextIn=(getIntent().getStringExtra("FullTextIn"));
        String tempCategoryIn=(getIntent().getStringExtra("CategoryIn"));
        String tempDecodedTextIn=AppSpecific.UnEncodeText(tempTextIn);

        tempCategoryIn=tempCategoryIn.replace("Category: ","");
        String tempNameIn=(getIntent().getStringExtra("NameIn"));
        String tempGradeIn=(getIntent().getStringExtra("GradeIn"));
        EntryPoint=(getIntent().getStringExtra("EntryPoint"));
        if (EntryPoint==null) EntryPoint="";
        ConfigDropdown(ddCategory,pCategoryList,tempCategoryIn);
        ConfigDropdown(ddGrade,pGradeList,tempGradeIn);
        IDIn=(getIntent().getStringExtra("IDIn"));
        if (IDIn.equals("-1"))
        {
            Button cmdDelete=findViewById(R.id.cmdDelete);
            cmdDelete.setEnabled(false);
            txtName.setTag(IDIn);
            txtName.setText(tempNameIn);
            txtFullText.setText(tempDecodedTextIn);
        }
        else
        {
            GetDataFromDB(IDIn);
        }
        PopupHelp();
    }
    private void PopupHelp()
    {
        if (GeneralFunctions01.Cfg.ReadSharedPreference(this,"TipAC").length()>0) return;
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        nsp.setContentView(R.layout.custom_dialog_trans_info_addcontent);
        Button buttonDismissTipKR = nsp.findViewById(R.id.buttonDismissTipAC);
        buttonDismissTipKR.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                WriteSharedPreference("TipAC","1");
                nsp.dismiss();
            }
        });
        nsp.show();
    }

    private void ConfigDropdown(Spinner pWhichDD, String[] pValArray, String pSetToText)
    {
        ArrayAdapter<String> adapterType = new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, pValArray);
        pWhichDD.setAdapter(adapterType);
        int setPosT=adapterType.getPosition(pSetToText);
        pWhichDD.setSelection(setPosT);
    }

    @Override
    public void onResume () {
        super.onResume();
    }
    private void GetDataFromDB(String IDIn)
    {
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        String AllData=myDb.getAllRowsAsString("SELECT * FROM tblUserDefined WHERE UD_ID='" + IDIn + "';");
        myDb.close();
        if (AllData.equals(null)) return;
        String[] lines=AllData.split("l#d");
        for (int i = 0; i < lines.length; i++) {
            String[] vals=lines[i].split("p#d");
            String pID= GeneralFunctions01.Text.GetValInArray(vals, 0);
            String pNameOfEntry= GeneralFunctions01.Text.GetValInArray(vals, 1);
            String pCategory=GeneralFunctions01.Text.GetValInArray(vals, 2);
            String pAllData=GeneralFunctions01.Text.GetValInArray(vals, 3);
            String pGrade=GeneralFunctions01.Text.GetValInArray(vals, 4);
            String pDisplayText=AppSpecific.UnEncodeText(pAllData);
            txtName.setText(pNameOfEntry);
            txtName.setTag(pID);
            ConfigDropdown(ddCategory,pCategoryList,pCategory);
            ConfigDropdown(ddGrade,pGradeList,pGrade);
            txtFullText.setText(pDisplayText);
        }
    }
    public void OnClickCancel(View arg0)
    {
        finish();
    }
    public void OnClickSave(View arg0)
    {
        Save();
    }

    private String isSaveValid()
    {
        String pTestIt;
        String pName=txtName.getText().toString();
        pTestIt=pName.replace(" ","");
        if (pTestIt.length()<1) return "The name/title you entered is invalid; please modify and try again.";
        String pCategory=ddCategory.getSelectedItem().toString();
        String pGrade=ddGrade.getSelectedItem().toString();
        String pFullText=txtFullText.getText().toString();
        pTestIt=pFullText.replace(" ","");
        if (pTestIt.length()<1) return "The content you entered is invalid; please modify and try again.";
        return "";
    }
    private void Save()
    {
        if (isSaveValid().length()>1)
        {
            GeneralFunctions01.Oth.Alert(this,isSaveValid());
            return;
        }
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        String pName=txtName.getText().toString();
        String pCategory=ddCategory.getSelectedItem().toString();
        String pGrade=ddGrade.getSelectedItem().toString();
        String pFullText=txtFullText.getText().toString();
        String pID=txtName.getTag().toString();
        pFullText=AppSpecific.EncodeText(pFullText);
        if (pID.equals("-1"))
        {
            String pAlreadyThere=myDb.getSingleValAsString("SELECT COUNT(*) FROM tblUserDefined WHERE UD_NameOfEntry='" + pName +"'");
            if (pAlreadyThere.equals("0"))
            {
                String pResult=myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words,UD_Grade) VALUES ('" + pName +"','" + pCategory +  "','" + pFullText + "','" + pGrade +  "')");
            }
            else
            {
                ShowNameAlreadyUsed();
                myDb.close();
                return;
                /*
                for (int i = 0; i < 999; i++) {
                    String pNumExt = String.format("%03d", i);
                    pAlreadyThere=myDb.getSingleValAsString("SELECT COUNT(*) FROM tblUserDefined WHERE UD_NameOfEntry='" + pName + " " + pNumExt + "'");
                    if (pAlreadyThere.equals("0")) {
                        String pResult = myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words,UD_Grade) VALUES ('" + pName + " " + pNumExt + "','" + pCategory + "','" + pFullText + "','" + pGrade +  "')");
                        break;
                    }
                }
                */
            }
        }
        else
        {
            String pResult=myDb.execSQL("UPDATE tblUserDefined SET UD_NameOfEntry='" + pName + "',UD_Category='" + pCategory + "',UD_Words='" + pFullText + "',UD_Grade='" + pGrade + "' WHERE UD_ID=" +pID +";");
        }
        String pCnt=myDb.getSingleValAsString("SELECT COUNT(*) FROM tblUserDefined");
        myDb.close();
        boolean pEmpty=false;
        if (pCnt.equals("1")) pEmpty=true;
        GoWhereNow(pEmpty);
        //finish();
    }
    public void GoWhereNow(boolean pEmpty)
    {
        //if (!EntryPoint.equals("DLArea")) finish();
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.setContentView(R.layout.custom_dialog_read_or_dl_more);
        //nsp.setTitle("Welcome to Pocket Cube Solver!");
        TextView textViewDynamic= nsp.findViewById(R.id.textViewDynamic);
        Button buttonGoToAdd = nsp.findViewById(R.id.buttonGoToAdd);
        Button buttonGoToRead = nsp.findViewById(R.id.buttonGoToRead);
        if (pEmpty==true)
        {
            textViewDynamic.setText("Now that you’ve saved a story, you can either…");
        }
        else
        {
            textViewDynamic.setText("Your data has been saved; do you want to…");
        }
        buttonGoToAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //nsp.dismiss();
                finish();
            }
        });
        buttonGoToRead.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                GoToTableOfUserData();
                finish();
                //nsp.dismiss();
            }
        });
        nsp.show();
    }
    private void GoToTableOfUserData()
    {
        Intent intent = new Intent(this, TableOfUserData.class);
        startActivity(intent);
    }
    public void OnClickDelete(View arg0)
    {
        Delete();
    }
    private void Delete() {

        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case DialogInterface.BUTTON_POSITIVE:
                        Log.d("APP", "Really Delete");
                        DoDelete();
                        break;

                    case DialogInterface.BUTTON_NEGATIVE:
                        Log.d("APP", "Dont Delete");
                        break;
                }
            }
        };

        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Are you sure?").setPositiveButton("Yes", dialogClickListener)
                .setNegativeButton("No", dialogClickListener).show();
    }

    private void DoDelete()
    {
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        String pResult=myDb.execSQL("DELETE FROM tblUserDefined WHERE UD_ID=" +IDIn);
        myDb.close();
        finish();
    }
    private void ShowNameAlreadyUsed()
    {
        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                //Just dismiss
            }
        };
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Oops!");
        builder.setMessage("You already have an entry titled\n\n" +
                txtName.getText().toString()+ "\n\n" +
                "Please rename this and save again.");
        builder.setNeutralButton("OK", dialogClickListener);
        AlertDialog dialog = builder.create();
        dialog.show();
    }
}
