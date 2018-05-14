package com.mc2techservices.kidsreadassistant;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.provider.Settings;
import android.util.Log;

import com.mc2techservices.kidsreadassistant.supportcode.AppSpecific;
import com.mc2techservices.kidsreadassistant.supportcode.FetchDataCallbackInterface;
import com.mc2techservices.kidsreadassistant.supportcode.GeneralFunctions01;

public class Splashscreen extends Activity implements FetchDataCallbackInterface {
    boolean pFirstSetup;
    @Override
    public void fetchDataCallback(String caller, String result) {
        Log.d("fetchDataCallback", caller + " came back with " + result);
        if (caller.equals("InitParameters"))
        {
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splashscreen);
        Init();
        LogUsage();
        CheckBetaStatus();
    }
    private void LogUsage()
    {
        String pURL= AppSpecific.gloWebServiceURL + "/LogUsage";
        String pParams = "pUUID="+AppSpecific.gloUUID+"&pChannel=Android";
        new GeneralFunctions01.AsyncWebCall().execute(pURL,pParams);
    }
    private void Init()
    {
        AppSpecific.gloPackageName = getApplicationContext().getPackageName();
        AppSpecific.gloLD="XZQX";
        AppSpecific.gloPD="~_~";
        AppSpecific.gloxmlns= "xmlns=\"kidsreader.mc2techservices.com\">";
        AppSpecific.gloWebURL="http://kidsreader.mc2techservices.com/";
        //AppSpecific.gloWebURL="http://192.168.199.1/KidsReader/";  //test
        AppSpecific.gloWebServiceURL=AppSpecific.gloWebURL + "KidsReader.asmx";
        if (GeneralFunctions01.Cfg.ReadSharedPreference(this, "UUID").equals(""))
        {
            pFirstSetup=true;
            String android_id = Settings.Secure.getString(this.getContentResolver(), Settings.Secure.ANDROID_ID);
            if (android_id==null) android_id="";
            if (android_id.length()<7) android_id=GeneralFunctions01.Text.GetRandomString("ANF", 8);
            GeneralFunctions01.Cfg.WriteSharedPreference(this, "UUID",android_id);
            SetFiltersOn();
        }
        AppSpecific.gloUUID=GeneralFunctions01.Cfg.ReadSharedPreference(this,"UUID");

        String pTempPitch=GeneralFunctions01.Cfg.ReadSharedPreference(this, "TTSPitch");
        if (pTempPitch.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"TTSPitch","100");
            AppSpecific.gloTTSPitch=100;
        }
        else
        {
            AppSpecific.gloTTSPitch=GeneralFunctions01.Conv.StringToInt(pTempPitch);
        }
        String pTempSpeed=GeneralFunctions01.Cfg.ReadSharedPreference(this, "TTSSpeed");
        if (pTempSpeed.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"TTSSpeed","100");
            AppSpecific.gloTTSSpeed=100;
        }
        else
        {
            AppSpecific.gloTTSSpeed=GeneralFunctions01.Conv.StringToInt(pTempSpeed);
        }
        String pTempWordPadding=GeneralFunctions01.Cfg.ReadSharedPreference(this, "WordPadding");
        if (pTempWordPadding.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"WordPadding","30");
            AppSpecific.gloWordPadding=30;
        }
        else
        {
            AppSpecific.gloWordPadding=GeneralFunctions01.Conv.StringToInt(pTempWordPadding);
        }

        String pDefaultReadMode=GeneralFunctions01.Cfg.ReadSharedPreference(this, "DefaultReadMode");
        if (pDefaultReadMode.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"DefaultReadMode","Scroll");
            AppSpecific.gloDefaultReadMode="Scroll";
        }
        else
        {
            AppSpecific.gloDefaultReadMode=pDefaultReadMode;
        }

        String pTextSize=GeneralFunctions01.Cfg.ReadSharedPreference(this, "TextSize");
        if (pTextSize.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"TextSize","10");
            AppSpecific.gloTextSize=10;
        }
        else
        {
            AppSpecific.gloTextSize=GeneralFunctions01.Conv.StringToInt(pTextSize);
        }

        String pShowSettings=GeneralFunctions01.Cfg.ReadSharedPreference(this, "ShowSettings");
        if (pTextSize.equals(""))
        {
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"ShowSettings","1");
            AppSpecific.gloShowSettings="1";
        }
        else
        {
            AppSpecific.gloShowSettings=pShowSettings;
        }
    }
    private void SetFiltersOn()
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGradeK","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGrade1","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGrade2","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGrade3","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGrade4","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterGrade5","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterStories","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterWordLists","true");
        GeneralFunctions01.Cfg.WriteSharedPreference(this,"FilterOther","true");
    }
    private void ShowExpired()
    {
        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                finish();
            }
        };
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Thanks for Trying!");
        builder.setMessage("This version has expired.  " +
                "An updated version should be available on the Google Play Store.\n" +
                "If this is not the case, please contact us.\n" +
                "service@mc2techservices.com.");
        builder.setNeutralButton("OK", dialogClickListener);
        AlertDialog dialog = builder.create();
        dialog.show();
    }

    private void CheckBetaStatus() {
        String pCurrDate=GeneralFunctions01.Dte.GetCurrentDate();
        long pDaysLeft=GeneralFunctions01.Dte.DaysBetweenDate(pCurrDate, "2020-05-15");
        if (pDaysLeft>0)
        {
            GoToMain();
        }
        else
        {
            ShowExpired();
        }
    }

    private void GoToMain()
    {
        Intent intent = new Intent(this, KidMode.class);
        startActivity(intent);
        finish();
    }
}
