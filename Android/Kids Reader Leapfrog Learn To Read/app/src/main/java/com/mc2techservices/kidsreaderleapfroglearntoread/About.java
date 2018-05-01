package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import com.mc2techservices.kidsreaderleapfroglearntoread.supportcode.AppSpecific;
public class About extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_about);
    }
    public void OnClickEmailMe(View arg0)
    {
        EmailMe();
    }
    private void EmailMe()
    {
        Intent email = new Intent(Intent.ACTION_SEND);
        email.setType("message/rfc822");
        email.putExtra(Intent.EXTRA_EMAIL, new String[]{"service@mc2techservices.com"});
        email.putExtra(Intent.EXTRA_SUBJECT, "Kids Reader Feedback " + AppSpecific.gloUUID);
        email.putExtra(Intent.EXTRA_TEXT, "");

        try {
            // the user can choose the email client
            startActivity(Intent.createChooser(email, "Choose an email client from..."));

        } catch (android.content.ActivityNotFoundException ex)
        {
        }
    }
    public void OnClickVisitWebSite(View arg0)
    {
        VisitWebSite("http://kidsreader.mc2techservices.com");
    }

    private void VisitWebSite(String url)
    {
        Uri uriUrl = Uri.parse(url);
        Intent launchBrowser = new Intent(Intent.ACTION_VIEW, uriUrl);
        startActivity(launchBrowser);
    }
}
