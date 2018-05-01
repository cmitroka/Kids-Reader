package com.mc2techservices.kidsreadassistant;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.mc2techservices.kidsreadassistant.supportcode.GeneralFunctions01;

public class ParentMode extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_parent_mode);
        PopupHelp();
    }
    public void OnClickAUserData(View arg0)
    {
        String pTempDSA=GeneralFunctions01.Cfg.ReadSharedPreference(this, "DSA");
        if (pTempDSA.equals("1"))
        {
            DoAddUserData();
        }
        else
        {
            AlertAboutWebOption();
        }

    }
    private void AlertAboutWebOption() {
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.setContentView(R.layout.custom_dialog_inform_about_web);
        //nsp.setTitle("Welcome to Pocket Cube Solver!");
        Button buttonGotIt = nsp.findViewById(R.id.buttonGotIt);
        buttonGotIt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CheckBox checkBoxDSA = nsp.findViewById(R.id.checkBoxDSA);
                if (checkBoxDSA.isChecked())
                {
                    WriteSharedPreference("DSA","1");
                }
                DoAddUserData();
                nsp.dismiss();
            }
        });
        nsp.show();
    }
    private void DoAddUserData()
    {
        Intent intent = new Intent(this, AddModDel.class);
        intent.putExtra("FullTextIn", "");
        intent.putExtra("CategoryIn", "");
        intent.putExtra("NameIn", "");
        intent.putExtra("IDIn", "-1");
        startActivity(intent);
    }

    public void OnClickDownloadUserContent(View arg0)
    {
        DownloadUserContent();
    }
    private void DownloadUserContent()
    {
        Intent intent = new Intent(this, DownloadUserContent.class);
        startActivity(intent);
        //finish();
    }
    public void OnClickDownloadOurContent(View arg0)
    {
        DownloadOurContent();
    }
    private void DownloadOurContent()
    {
        Intent intent = new Intent(this, TableOfOurData.class);
        startActivity(intent);
        //finish();
    }

    public void OnClickMDUserData(View arg0)
    {
        ModDelUserData();
    }
    private void ModDelUserData()
    {
        Intent intent = new Intent(this, TableOfUserDataMD.class);
        startActivity(intent);
    }

    public void OnClickVideoTutorial(View arg0)
    {
        VisitWebSite("https://youtu.be/WhLYFaIu5vs");
    }

    private void VisitWebSite(String url)
    {
        Uri uriUrl = Uri.parse(url);
        Intent launchBrowser = new Intent(Intent.ACTION_VIEW, uriUrl);
        startActivity(launchBrowser);
    }

    public void OnClickSettings(View arg0)
    {
        Settings();
    }
    private void Settings()
    {
        Intent intent = new Intent(this, Settings.class);
        intent.putExtra("EntryPoint", "ParentMode");
        startActivity(intent);
    }

    public void OnClickAboutTheApp(View arg0)
    {
        AboutTheApp();
    }
    private void AboutTheApp()
    {
        Intent intent = new Intent(this, About.class);
        startActivity(intent);
    }

    private void PopupHelp()
    {
        if (GeneralFunctions01.Cfg.ReadSharedPreference(this,"TipPM").length()>0) return;
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        nsp.setContentView(R.layout.custom_dialog_trans_info_parentmode);
        Button buttonDismissTipKR = nsp.findViewById(R.id.buttonDismissTipPM);
        buttonDismissTipKR.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                WriteSharedPreference("TipPM","1");
                nsp.dismiss();
            }
        });
        nsp.show();
    }

    public void OnClickChangePassword(View arg0)
    {
        ChangePassword();
    }
    private void ChangePassword()
    {
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.setContentView(R.layout.custom_dialog_login);
        //nsp.setTitle("Welcome to Pocket Cube Solver!");
        Button cmdContinue = nsp.findViewById(R.id.buttonContinue);
        Button cmdCancel = nsp.findViewById(R.id.buttonCancel);
        TextView textViewDescription = nsp.findViewById(R.id.textViewDescription);
        textViewDescription.setText("Please enter what you would like to change your password to:");
        cmdContinue.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText editTextPassword= nsp.findViewById(R.id.editTextPassword);
                EditText editTextConfirmPassword= nsp.findViewById(R.id.editTextConfirmPassword);
                String p1=editTextPassword.getText().toString().toLowerCase();
                String p2=editTextConfirmPassword.getText().toString().toLowerCase();
                if (p1.equals(p2))
                {
                    WriteSharedPreference("AdminPass",p1);
                    Toast.makeText(getApplicationContext(), "Password Updated", Toast.LENGTH_SHORT).show();
                    nsp.dismiss();
                }
                else
                {
                    AlertPasswordMismatch();
                }
            }
        });
        cmdCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                nsp.dismiss();
            }
        });
        nsp.show();
    }
    private void WriteSharedPreference(String pKey, String pVal)
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,pKey,pVal);
    }
    private void AlertPasswordMismatch()
    {
        GeneralFunctions01.Oth.Alert(this,"The password / confrim password you entered didn't match.");
    }
}
