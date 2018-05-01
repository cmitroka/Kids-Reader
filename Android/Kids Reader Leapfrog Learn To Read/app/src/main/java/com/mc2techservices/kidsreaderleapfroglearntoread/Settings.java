package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.RadioButton;
import android.widget.SeekBar;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.AppSpecific;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

public class Settings extends Activity {
    SeekBar uiSeekBarPitch;
    SeekBar uiSeekBarSpeed;
    SeekBar uiSeekTextSize;
    SeekBar uiSeekWordPadding;
    RadioButton rbScrolling;
    RadioButton rbPages;
    CheckBox checkboxDontShowSettings;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
        Init();
    }

    private void Init()
    {
        checkboxDontShowSettings=findViewById(R.id.checkboxDontShowSettings);
        uiSeekBarPitch =findViewById(R.id.uiSeekBarPitch);
        uiSeekBarPitch.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            int progressChangedValue = 0;
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                progressChangedValue = progress;
            }
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }
            public void onStopTrackingTouch(SeekBar seekBar) {
                AppSpecific.gloTTSPitch=progressChangedValue;
                WriteSharedPref("TTSPitch",String.valueOf(progressChangedValue));
                //Toast.makeText(getApplicationContext(), "Seek bar progress is :" + progressChangedValue,Toast.LENGTH_SHORT).show();
            }
        });
        uiSeekBarSpeed =findViewById(R.id.uiSeekBarSpeed);
        uiSeekBarSpeed.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            int progressChangedValue = 0;
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                progressChangedValue = progress;
            }
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }
            public void onStopTrackingTouch(SeekBar seekBar) {
                AppSpecific.gloTTSSpeed=progressChangedValue;
                WriteSharedPref("TTSSpeed",String.valueOf(progressChangedValue));
                //Toast.makeText(getApplicationContext(), "Seek bar progress is :" + progressChangedValue,Toast.LENGTH_SHORT).show();
            }
        });
        uiSeekWordPadding =findViewById(R.id.uiSeekWordPadding);
        uiSeekWordPadding.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            int progressChangedValue = 0;
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                progressChangedValue = progress;
            }
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }
            public void onStopTrackingTouch(SeekBar seekBar) {
                AppSpecific.gloWordPadding=progressChangedValue;
                WriteSharedPref("WordPadding",String.valueOf(progressChangedValue));
                //Toast.makeText(getApplicationContext(), "Seek bar progress is :" + progressChangedValue,Toast.LENGTH_SHORT).show();
            }
        });
        uiSeekTextSize =findViewById(R.id.uiSeekTextSize);
        uiSeekTextSize.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            int progressChangedValue = 0;
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                progressChangedValue = progress;
            }
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }
            public void onStopTrackingTouch(SeekBar seekBar) {
                AppSpecific.gloTextSize=progressChangedValue;
                WriteSharedPref("TextSize",String.valueOf(progressChangedValue));
            }
        });



        SetSliders();
        rbScrolling=findViewById(R.id.rbScrolling);
        rbPages=findViewById(R.id.rbPages);
        SetDefaultReadMode();
        SetShowSettingFromReader();
        String pEntryPoint=(getIntent().getStringExtra("EntryPoint"));
        if (pEntryPoint.equals("Reader")) checkboxDontShowSettings.setEnabled(false);
    }


    private void SetDefaultReadMode()
    {
        if (AppSpecific.gloDefaultReadMode.equals("Scroll"))
        {
            rbScrolling.setChecked(true);
            rbPages.setChecked(false);
        }
        else
        {
            rbScrolling.setChecked(false);
            rbPages.setChecked(true);
        }
    }

    private void SetShowSettingFromReader()
    {
        if (AppSpecific.gloShowSettings.equals("1"))
        {
            checkboxDontShowSettings.setChecked(true);
        }
        else
        {
            checkboxDontShowSettings.setChecked(false);
        }
    }

    private void SetSliders()
    {
        uiSeekTextSize.setProgress(AppSpecific.gloTextSize);
        uiSeekBarPitch.setProgress(AppSpecific.gloTTSPitch);
        uiSeekBarSpeed.setProgress(AppSpecific.gloTTSSpeed);
        uiSeekWordPadding.setProgress(AppSpecific.gloWordPadding);
    }
    private void WriteSharedPref(String pPref, String pVal)
    {
        GeneralFunctions01.Cfg.WriteSharedPreference(this,pPref,pVal);
    }

    public void onCheckboxDontShowSettingsClicked(View view) {
        if (checkboxDontShowSettings.isChecked())
        {
            checkboxDontShowSettings.setChecked(true);
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"ShowSettings","1");
            AppSpecific.gloShowSettings="1";
        }
        else
        {
            checkboxDontShowSettings.setChecked(false);
            GeneralFunctions01.Cfg.WriteSharedPreference(this,"ShowSettings","0");
            AppSpecific.gloShowSettings="0";
        }
    }

    public void onClickResetPitch(View view) {
        uiSeekBarPitch.setProgress(100);
        WriteSharedPref("TTSPitch",String.valueOf(100));
        AppSpecific.gloTTSPitch=100;
    }
    public void onClickResetSpeed(View view) {
        uiSeekBarSpeed.setProgress(100);
        WriteSharedPref("TTSSpeed",String.valueOf(100));
        AppSpecific.gloTTSSpeed=100;
    }
    public void onClickResetTextSize(View view) {
        uiSeekTextSize.setProgress(10);
        WriteSharedPref("TextSize",String.valueOf(10));
        AppSpecific.gloTextSize=10;
    }

    public void onClickResetWordPadding(View view) {
        uiSeekWordPadding.setProgress(30);
        WriteSharedPref("WordPadding",String.valueOf(30));
        AppSpecific.gloWordPadding=30;
    }


    public void onRadioButtonClicked(View view) {
        // Is the button now checked?
        boolean checked = ((RadioButton) view).isChecked();

        // Check which radio button was clicked
        switch(view.getId()) {
            case R.id.rbPages:
                if (checked)
                    GeneralFunctions01.Cfg.WriteSharedPreference(this,"DefaultReadMode","Page");
                    AppSpecific.gloDefaultReadMode="Page";
                    break;
            case R.id.rbScrolling:
                if (checked)
                    GeneralFunctions01.Cfg.WriteSharedPreference(this,"DefaultReadMode","Scroll");
                    AppSpecific.gloDefaultReadMode="Scroll";
                    break;
        }
    }
}
