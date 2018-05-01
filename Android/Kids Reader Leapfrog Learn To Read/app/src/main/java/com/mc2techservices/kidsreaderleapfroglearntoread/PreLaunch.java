package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.DBAdapter;

public class PreLaunch extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pre_launch);
        //DeleteDB();
        //Setup();
        Intent intent = new Intent(this, Splashscreen.class);
        startActivity(intent);
        finish();
    }
    private void DeleteDB()
    {
        DBAdapter myDb = new DBAdapter(this);
        myDb.open();
        myDb.deleteDB(this);
        myDb.close();
    }
    private void Setup()
    {
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        myDb.deleteDB(this);
        myDb.close();
        myDb.open();
        myDb.execSQL("DELETE FROM tblUserDefined");
        myDb.execSQL("DELETE FROM tblAppParams");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Trick Words','Word List','been both carry change city come could eight every family house large move night none only place please right some something together were where write')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Normal Words','Word List','banjo basic bingo bravely cozy crazy crunchy depend dizzy donate duty eject empty flu fluffy granny gravy grumpy happy jelly lazy locate lumpy native penny pony predict pretend program protect remind retire rewind sadly safety shy taffy try tulip ugly')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Test Story 1','Story','Three Little Pigs')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Test Story 2','Story','The Cat in the Hat')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Random Article 1','Other','Unique Valentine's Day Traditions From Around The World')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Random Article 2','Other','Grammy Awards Fast Facts')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Random Article 3','Other','Puppy Bowl 14 Promises Viewers A Paw-some Time On Super Bowl Sunday')");
        myDb.execSQL("INSERT INTO tblUserDefined (UD_NameOfEntry,UD_Category,UD_Words) VALUES ('Random Article 4','Other','Punxsutawney Phil Predicts An Extended Winter')");
        myDb.execSQL("INSERT INTO tblAppParams (AP_Key,AP_Value) VALUES ('Category','')");
        myDb.execSQL("INSERT INTO tblAppParams (AP_Key,AP_Value) VALUES ('Category','Story')");
        myDb.execSQL("INSERT INTO tblAppParams (AP_Key,AP_Value) VALUES ('Category','Word List')");
        myDb.execSQL("INSERT INTO tblAppParams (AP_Key,AP_Value) VALUES ('Category','Other')");
        myDb.close();
    }

}
