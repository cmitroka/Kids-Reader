package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.app.Dialog;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.DBAdapter;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

public class KidMode extends Activity {
    android.support.constraint.ConstraintLayout layoutRead;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_kid_mode);
        Initialize();
    }
    public void onResume () {
        super.onResume();
        PopupHelp();
    }

    public void OnClickLoadUserData(View arg0)
    {
        LoadUserData();
    }
    private void LoadUserData()
    {
        DBAdapter myDb  = new DBAdapter(this);
        myDb.open();
        String AllBHData=myDb.getSingleValAsString("SELECT COUNT(*) FROM tblUserDefined;");
        myDb.close();
        if (AllBHData.equals("0"))
        {
            AlertAboutNoData();
        }
        else
        {
            Intent intent = new Intent(this, TableOfUserData.class);
            //Intent intent = new Intent(this, TestActivity.class);

            startActivity(intent);
            //finish();
        }
    }


    private void TestDialog()
    {
        Intent intent = new Intent(this, TestActivityDialogs.class);
        startActivity(intent);
    }


    private void PopupHelp()
    {
        if (GeneralFunctions01.Cfg.ReadSharedPreference(this,"TipKR").length()>0) return;
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        nsp.setContentView(R.layout.custom_dialog_trans_info_kidmode);
        Button buttonDismissTipKR = nsp.findViewById(R.id.buttonDismissTipKR);
        buttonDismissTipKR.setOnClickListener(new View.OnClickListener() {
                                           @Override
                                           public void onClick(View v) {
                                               WriteSharedPreference("TipKR","1");
                                               nsp.dismiss();
                                           }
                                       });
                nsp.show();
    }


    private void AlertAboutNoData() {
        GeneralFunctions01.Oth.Alert(this, "You have no stories or word lists yet.  Please tap ‘Settings / Parent Mode’ to add stories or word list to use.");
    }

    public void OnClickDoParentMode(View arg0)
    {
        DoParentMode();
    }


    private void DoParentMode()
    {
        String pMode="";
        String pAdminPass=GeneralFunctions01.Cfg.ReadSharedPreference(this, "AdminPass");
        if (pAdminPass.equals(""))
        {
            PopupLogin("");
        }
        else if (pAdminPass.equals("NONESETUP"))
        {
            GoToParentMode();
        }
        else if (pAdminPass.length()>0)
        {
            PopupLogin(pAdminPass);
        }
    }

    private void Initialize() {
        layoutRead = findViewById(R.id.layoutRead);
    }

    private void PopupLogin(String pPasswordIn)
    {
        final String pPassword=pPasswordIn.toLowerCase();
        final Dialog nsp = new Dialog(this);
        nsp.requestWindowFeature(Window.FEATURE_NO_TITLE);
        nsp.setContentView(R.layout.custom_dialog_login);
        //nsp.setTitle("Welcome to Pocket Cube Solver!");
        Button cmdContinue = nsp.findViewById(R.id.buttonContinue);
        Button cmdCancel = nsp.findViewById(R.id.buttonCancel);
        TextView textViewDescription = nsp.findViewById(R.id.textViewDescription);
        EditText editTextConfirmPassword= nsp.findViewById(R.id.editTextConfirmPassword);
        TextView textViewConfirmPassword = nsp.findViewById(R.id.textViewConfirmPassword);
        String pMessage="";
        if (pPassword.equals(""))
        {
            pMessage="There’s currently no password set.  We advise setting this so little fingers don’t go tapping through areas they won’t understand.  You can do this now, or continue without setting one.";
            editTextConfirmPassword.setVisibility(View.VISIBLE);
            textViewConfirmPassword.setVisibility(View.VISIBLE);
        }
        else
        {
            pMessage="Please enter your password to access this area.";
            editTextConfirmPassword.setVisibility(View.INVISIBLE);
            textViewConfirmPassword.setVisibility(View.INVISIBLE);
        }
        textViewDescription.setText(pMessage);
        cmdContinue.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText editTextPassword= nsp.findViewById(R.id.editTextPassword);
                EditText editTextConfirmPassword= nsp.findViewById(R.id.editTextConfirmPassword);
                String p1=editTextPassword.getText().toString().toLowerCase();
                String p2=editTextConfirmPassword.getText().toString().toLowerCase();
                if (pPassword.equals(""))
                {
                    if (p1.equals(p2))
                    {
                        if (p1.equals(""))
                        {
                            WriteSharedPreference("AdminPass","NONESETUP");
                        }
                        else
                        {
                            WriteSharedPreference("AdminPass",p1);
                        }
                        GoToParentMode();
                        nsp.dismiss();
                    }
                    else
                    {
                        AlertPasswordMismatch();
                    }
                }
                else
                {
                    if (p1.equals(pPassword))
                    {
                        GoToParentMode();
                        nsp.dismiss();
                    }
                    else
                    {
                        AlertInvalidPassword();
                    }
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

    private void AlertPasswordMismatch()
    {
        GeneralFunctions01.Oth.Alert(this,"The password / confrim password you entered didn't match.");
    }
    private void AlertInvalidPassword()
    {
        GeneralFunctions01.Oth.Alert(this,"The password you entered does not match what we have saved.");
    }
    private void WriteSharedPreference(String pKey, String pValue)
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,pKey,pValue);
    }

    private void GoToParentMode()
    {
        Intent intent = new Intent(this, ParentMode.class);
        startActivity(intent);
    }


}
