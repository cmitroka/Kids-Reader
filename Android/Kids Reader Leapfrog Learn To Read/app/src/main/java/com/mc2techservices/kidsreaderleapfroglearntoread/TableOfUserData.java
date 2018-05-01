package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.DBAdapter;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

public class TableOfUserData extends Activity {
    TextView txtNoUserDataEntries;
    LinearLayout llUserDataEntries;
    String pWhereClause;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_table_of_user_data);
    }

    public void onResume () {
        super.onResume();
        Initialize();
    }

    private void Initialize()
    {
        txtNoUserDataEntries=findViewById(R.id.txtNoUserDataEntries);
        llUserDataEntries=findViewById(R.id.llUserDataEntries);
        llUserDataEntries.removeAllViews();
        Populate();
    }

    private void Populate() {
        PopulateTableEntries();
    }
    private void PopulateTableEntries() {
        PopulateTableEntries("SELECT * FROM tblUserDefined;");
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
            String[] vals=lines[i].split("p#d");
            //UD_ID integer primary key, UD_NameOfEntry text, UD_Category text, UD_Words
            String pAllData=GeneralFunctions01.Text.GetValInArray(vals, 3);
            String pNameOfEntry=GeneralFunctions01.Text.GetValInArray(vals, 1);
            String pCategory=GeneralFunctions01.Text.GetValInArray(vals, 2);
            String pGradeLevel=GeneralFunctions01.Text.GetValInArray(vals, 4);
            LinearLayout bhrow = BuildTableRow(pNameOfEntry, pAllData, pCategory, pGradeLevel);
            llUserDataEntries.addView(bhrow);
            empty = false;
        }
        if (empty == true) {
            llUserDataEntries.addView(txtNoUserDataEntries);
        }
    }

    private void SetToGrade(ImageView ivIn, String pGradeLevel)
    {
        if (pGradeLevel.equals("K"))
        {
            ivIn.setImageResource(R.drawable.gk);
        }
        else if (pGradeLevel.equals("1"))
        {
            ivIn.setImageResource(R.drawable.g1);
        }
        else if (pGradeLevel.equals("2"))
        {
            ivIn.setImageResource(R.drawable.g2);
        }
        else if (pGradeLevel.equals("3"))
        {
            ivIn.setImageResource(R.drawable.g3);
        }
        else if (pGradeLevel.equals("4"))
        {
            ivIn.setImageResource(R.drawable.g4);
        }
        else if (pGradeLevel.equals("5"))
        {
            ivIn.setImageResource(R.drawable.g5);
        }
        else
        {
            ivIn.setImageResource(R.drawable.gbook);
        }
    }

    private LinearLayout BuildTableRow(String pNameIn, String pFullTextIn, String pCategoryIn, String pGradeLevel)
    {
        LinearLayout row = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.cell_user_data_entry_00, null);
        ((TextView)row.findViewById(R.id.textViewCUDTitle)).setText(pNameIn);
        (row.findViewById(R.id.textViewCUDTitle)).setTag(pFullTextIn);
        ((TextView)row.findViewById(R.id.textViewCUDCategory)).setText("Category: " + pCategoryIn);
        String[] pWords=pFullTextIn.split(" ");
        ((TextView)row.findViewById(R.id.textViewCUDWords)).setText("Words: " + pWords.length);
        ImageView i=row.findViewById(R.id.imageViewCUDGrade);
        SetToGrade(i, pGradeLevel);
        row.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                TextView txtCellName=v.findViewById(R.id.textViewCUDTitle);
                String pTemp=txtCellName.getTag().toString();
                String pTitle=txtCellName.getText().toString();
                LoadReader(pTemp,pTitle);
            }
        });
        return row;
    }

    private void LoadReader(String pWhatToRead, String pTitle)
    {
        Intent intent = new Intent(this, Reader.class);
        intent.putExtra("FullText", pWhatToRead);
        intent.putExtra("Title", pTitle);
        //intent.putExtra("FullText", "been");
        startActivity(intent);
    }

}
