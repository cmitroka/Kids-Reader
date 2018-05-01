package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.text.InputFilter;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.AppSpecific;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.FetchData;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.FetchDataCallbackInterface;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

public class DownloadUserContent extends Activity implements FetchDataCallbackInterface {
    EditText txtGetData;
    @Override
    public void fetchDataCallback(String caller, String result) {
        Log.d("fetchDataCallback", caller + " came back with " + result);
        if (result==null) return;
        if (caller.equals("GetUserData"))
        {
            if (result.length()==0)  //
            {
                GeneralFunctions01.Oth.Alert(this, "Sorry, we couldn't find anything with the ID you provided.");
            }
            else
            {
                result=result.replace("<newkrline>","\n");
                LoadUserData(result);
            }
        }
    }

    private void LoadUserData(String pAllData)
    {
        Intent intent = new Intent(this, AddModDel.class);
        intent.putExtra("FullTextIn", pAllData);
        intent.putExtra("IDIn", "-1");
        intent.putExtra("CategoryIn", "");
        intent.putExtra("NameIn", "");
        intent.putExtra("IDIn", "-1");
        startActivity(intent);
        finish();
    }

    private void SetCapitalizationFilter()
    {
        InputFilter[] editFilters = txtGetData.getFilters();
        InputFilter[] newFilters = new InputFilter[editFilters.length + 1];
        System.arraycopy(editFilters, 0, newFilters, 0, editFilters.length);
        txtGetData.setFilters(new InputFilter[] {new InputFilter.AllCaps()});
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_download_user_content);
        txtGetData=findViewById(R.id.txtGetData);
        SetCapitalizationFilter();

    }
    @Override
    public void onResume () {
        super.onResume();
    }

    public void OnClickGetUserData(View arg0) {
        GetUserData();
    }

    private void GetUserData() {
        String pURL = AppSpecific.gloWebServiceURL + "/GetUserDoc";
        String pParams = "pCode=" + txtGetData.getText();
        new FetchData("GetUserData", pURL, pParams, AppSpecific.gloxmlns,  3, this).execute();

    }
}