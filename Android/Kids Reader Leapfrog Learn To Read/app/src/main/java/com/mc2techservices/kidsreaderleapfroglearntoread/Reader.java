package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.app.Dialog;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.AppSpecific;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.FlowLayout;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.GeneralFunctions01;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Reader extends Activity implements TextToSpeech.OnInitListener{
    Timer defaultModeSwitcher;
    Timer beginCompleteIt;
    TextToSpeech tts;
    String pFullText;
    int pPageReading;
    ArrayList<String> pPages;
    String pReadMode;
    Dialog pWaitingOverlay;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reader);
    }

    @Override
    public void onResume () {
        super.onResume();
        Initialize();
        ActivateBeginCompleteIt();
        //CompleteIt();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.reader_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle item selection
        Intent intent;
        switch (item.getItemId()) {
            case R.id.mnuChangeReadMode:
                ChangeReadMode("");
                return true;
            case R.id.mnuSettings:
                ShowSettings();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }


    private void Initialize()
    {
        beginCompleteIt=new Timer();
        pFullText=(getIntent().getStringExtra("FullText"));
        pFullText=AppSpecific.UnEncodeText(pFullText);

        String pTitle=getIntent().getStringExtra("Title");
        this.setTitle(pTitle);

        tts = new TextToSpeech(this,this);


        int iPitch=AppSpecific.gloTTSPitch-99;
        double dPitch=1+(iPitch*.01);
        float fPitchMod=(float)dPitch;
        tts.setPitch(fPitchMod);

        int iSpeed=AppSpecific.gloTTSSpeed-99;
        double dSpeed=1+(iSpeed*.01);
        float fSpeedMod=(float)dSpeed;
        tts.setSpeechRate(fSpeedMod);
        //tts.setLanguage(Locale.US);
        pReadMode=AppSpecific.gloDefaultReadMode;
        if (!pReadMode.equals("Scroll"))
        {
            ActivateIntialModeSwitch();
        }
    }


    private void ActivateBeginCompleteIt()
    {
        ShowWaiting();
        beginCompleteIt.scheduleAtFixedRate(new TimerTask() {
            public void run() {
                runOnUiThread(new Runnable() {
                    public void run() {
                        beginCompleteIt.cancel();
                        CompleteIt();
                        Log.d("APP", "CompleteIt");

                    }
                });
            }
        }, 2000, 10000); // 1000 means start delay (1 sec), and the second is the loop delay.
    }


    private void ActivateIntialModeSwitch()
    {
        defaultModeSwitcher=new Timer();
        ShowWaiting();
        defaultModeSwitcher.scheduleAtFixedRate(new TimerTask() {
            public void run() {
                runOnUiThread(new Runnable() {
                    public void run() {
                        defaultModeSwitcher.cancel();
                        pWaitingOverlay.dismiss();
                        ChangeReadMode("Scroll");
                        Log.d("APP", "defaultModeSwitcher ran");

                    }
                });
            }
        }, 2500, 10000); // 1000 means start delay (1 sec), and the second is the loop delay.
    }

    private void ShowSettings()
    {
        if (AppSpecific.gloShowSettings.equals("1"))
        {
            Intent intent = new Intent(this, Settings.class);
            intent.putExtra("EntryPoint", "Reader");
            startActivity(intent);
        }
        else
        {
            GeneralFunctions01.Oth.Alert(this, "Disabled - Please turn this on from the main screens Settings / Parent Mode.");
        }
    }



    private void ShowWaiting()
    {
        pWaitingOverlay = new Dialog(this);
        pWaitingOverlay.requestWindowFeature(Window.FEATURE_NO_TITLE);
        pWaitingOverlay.setContentView(R.layout.overlay_waiting);
        pWaitingOverlay.show();
    }


    private void ChangeReadMode(String pOverrideModeToUse) {
        if (!pOverrideModeToUse.equals("")) pReadMode=pOverrideModeToUse;
        Button buttonNavNext=findViewById(R.id.buttonNavNext);
        Button buttonNavBack=findViewById(R.id.buttonNavBack);
        if (pReadMode.equals("Scroll"))
        {
            LoadToPageMode(pFullText);
            SetNavTexts();
            pReadMode="Page";
            buttonNavNext.setVisibility(View.VISIBLE);
            buttonNavBack.setVisibility(View.VISIBLE);
        }
        else
        {
            LoadToScrollMode(pFullText);
            pReadMode="Scroll";
            //SetNavTexts();
            TextView textViewPageXofY=findViewById(R.id.textViewPageXofY);
            textViewPageXofY.setText("Scroll Up and Down");
            buttonNavNext.setVisibility(View.INVISIBLE);
            buttonNavBack.setVisibility(View.INVISIBLE);
        }
    }


    private void CompleteIt()
    {
        pPages = new ArrayList<String>();
        //pReadMode="Scroll";
        int pStartPos=pFullText.length()-1;
        String pLastChar=pFullText.substring(pStartPos,pStartPos+1);
        if (!pLastChar.equals(" ")) {
            pFullText=pFullText+" ";
        }
        ChangeReadMode("Page");
        LoadToScrollMode(pFullText);
    }

    private void SetNavTexts()
    {
        Button buttonNavNext=findViewById(R.id.buttonNavNext);
        if ((pPageReading+1)>=pPages.size())
        {
            buttonNavNext.setEnabled(false);
        }
        else
        {
            buttonNavNext.setEnabled(true);
        }
        Button buttonNavBack=findViewById(R.id.buttonNavBack);
        if ((pPageReading-1)<0)
        {
            buttonNavBack.setEnabled(false);
        }
        else
        {
            buttonNavBack.setEnabled(true);
        }
        TextView textViewPageXofY=findViewById(R.id.textViewPageXofY);
        textViewPageXofY.setText((pPageReading+1)+ " of " + pPages.size());
        //textViewPageXofY.setText("Scroll Up and Down");
    }

    public void onClickNavForwards(View arg0) {
        pPageReading++;
        SetNavTexts();
        LoadToScrollMode(pPages.get(pPageReading));
    }
    public void onClickNavBack(View arg0) {
        pPageReading--;
        SetNavTexts();
        LoadToScrollMode(pPages.get(pPageReading));
    }

    public void onInit(int i)
    {
        //doSpeak("Speech is now enabled");
    }


    private void LoadToPageMode(String pTextIn)
    {
        pPages.clear();
        int pNavBarXPosition;  //Need this
        int pFirstLineXPos=0;
        int pHeightAmntPerRow=0;
        int pAmntOfRows=1;
        LinearLayout layoutNav=findViewById(R.id.layoutNav);
        int LinearLayoutPos[] = new int[2];
        layoutNav.getLocationInWindow(LinearLayoutPos);
        pNavBarXPosition=LinearLayoutPos[1];


        FlowLayout layout=findViewById(R.id.layoutDynamic);
        int count = layout.getChildCount();
        View v = null;
        int pPriorLoc=-1;
        int pCurrLoc=0;
        int pCurrentElemIndex=0;
        int pLastWordProcessedLoc=0;

        for(int i=0; i<count; i++) {
            pCurrentElemIndex=i;
            v = layout.getChildAt(i);
            EditText et=(EditText)v;
            //do something with your child element
            int test1[] = new int[2];
            v.getLocationInWindow(test1);
            if (pFirstLineXPos==0)   pFirstLineXPos=test1[1];
            if (pPriorLoc==-1)
            {
                pPriorLoc=0;
                pCurrLoc=test1[1];
                continue;
            }
            pPriorLoc=pCurrLoc;
            pCurrLoc=test1[1];
            boolean pFinalEntry=false;
            boolean pNewLine=false;
            boolean pNewPage=false;
            int pLastElementNumber=count-1;
            if (pPriorLoc!=pCurrLoc)
            {
                pNewLine=true;
            }
            if (i==pLastElementNumber)
            {
                pFinalEntry=true;
            }
            if (pNewLine==true)
            {
                //We're on a new line.
                pAmntOfRows++;
                if (pHeightAmntPerRow==0)
                {
                    pHeightAmntPerRow=pCurrLoc-pPriorLoc;
                }
                //Do we need a new page?
                if ((pAmntOfRows*pHeightAmntPerRow)+pFirstLineXPos>pNavBarXPosition) pNewPage=true;
            }
            if (pNewPage==true||pFinalEntry==true)
            {

                pAmntOfRows=1;
                if (pFinalEntry==true)i++;
                GetWordsForPage(pLastWordProcessedLoc,i);
                pLastWordProcessedLoc=i;
            }


        }
        layout.removeAllViews();
        pPageReading=0;
        SetNavTexts();
        LoadToScrollMode(pPages.get(pPageReading));
    }

    private void GetWordsForPage(int pStartAt, int pEndAt)
    {
        FlowLayout layout=findViewById(R.id.layoutDynamic);
        String pPagesWord="";
        for(int j=pStartAt; j<pEndAt; j++) {
            View v = layout.getChildAt(j);
            EditText et1=(EditText)v;
            String pWordSpace="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            String pTestWord=et1.getText().toString();
            if (pTestWord.equals(pWordSpace))
            {
                pPagesWord=pPagesWord+"\n";
            }
            else
            {
                pPagesWord=pPagesWord+ et1.getText().toString() + " ";
            }
        }
        pPages.add(pPagesWord); //this adds an element to the list.
    }

    private String FixLineBreaks(String pTextIn)
    {
        for(int i=0;i<10;i++) {
            pTextIn=pTextIn.replace("\n\n", "\n");
        }
        return pTextIn;
    }
    private void doSpeak(String pText)
    {
        tts.speak(pText, TextToSpeech.QUEUE_ADD, null);
    }
    private void LoadToScrollMode(String pFullText)
    {
        EditText btn = new EditText(this);
        FlowLayout llD=findViewById(R.id.layoutDynamic);
        llD.removeAllViews();
        String pTempFullText=FixLineBreaks(pFullText);
        pTempFullText=pTempFullText.replace("\n", " \n ");
        String[] arrTest=pTempFullText.split(" ");
        for(int i=0;i<arrTest.length;i++) {
            btn = CreateEditTextButton(arrTest[i]);
            if (btn!=null) llD.addView(btn);
        }
        pWaitingOverlay.dismiss();
    }
    private EditText CreateEditTextButton(String pWord)
    {
        if (pWord.equals("")) return null;
        EditText btn = new EditText(this);
        int pTextSizeMod=AppSpecific.gloTextSize-10;
        //btn.setId(i+1);
        if (pWord.equals("\n"))
        {
            pWord="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            btn.setVisibility(View.INVISIBLE);
            final FlowLayout.LayoutParams lparams = new FlowLayout.LayoutParams(0,-100); // Width , height
            btn.setLayoutParams(lparams);
        }
        else
        {
            int pWordPadding = (60-AppSpecific.gloWordPadding);
            pWordPadding=30-pWordPadding;
            final FlowLayout.LayoutParams lparams = new FlowLayout.LayoutParams(pWordPadding,-15); // Width , height
            btn.setLayoutParams(lparams);
        }
        btn.setTextColor(Color.parseColor("#000000"));
        btn.setTextSize(21+pTextSizeMod);
        btn.setText(pWord);
        btn.setFocusable(false);
        //btn.setLayoutParams(new ViewGroup.LayoutParams(
        //        ViewGroup.LayoutParams.WRAP_CONTENT,
        //        ViewGroup.LayoutParams.WRAP_CONTENT));
        //final int index = i;
        final String pFinalWord=pWord;
        btn.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                //Log.i("TAG", "The index is " + index + " and the word is " + pFinalWord);
                doSpeak(pFinalWord);
            }
        });
        return btn;
    }

}
