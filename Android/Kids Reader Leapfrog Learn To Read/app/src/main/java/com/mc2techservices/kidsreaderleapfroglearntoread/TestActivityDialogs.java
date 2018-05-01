package com.mc2techservices.kidsreaderleapfroglearntoread;

import android.app.Dialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.Window;
import android.view.WindowManager;

public class TestActivityDialogs extends AppCompatActivity {

    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test_dialogs);

        Dialog dialog = new Dialog(this);

        // SetContentView can be set to a View can simply specify the resource ID
        // LayoutInflater
        // li=(LayoutInflater)getSystemService(LAYOUT_INFLATER_SERVICE);
        // View v=li.inflate(R.layout.dialog_layout, null);
        // dialog.setContentView(v);
        dialog.setContentView(R.layout.test_dialog);

        dialog.setTitle("Custom Dialog");

        /*
         * Set the access window object Christmas box and parameter object to modify the layout of the dialog,
         * Can directly call getWindow (), said the Activity Window
         * Object, attribute that can change the Activity in the same way
         */
        Window dialogWindow = dialog.getWindow();
        WindowManager.LayoutParams lp = dialogWindow.getAttributes();
        dialogWindow.setGravity(Gravity.LEFT | Gravity.TOP);

        /*
         * Lp.x and lp.y expressed relative to offset the original position
         * When the parameter value contains the Gravity.LEFT, dialog box appears on the left, so lp.x said offset relative to the left, negative neglect
         * When the parameter value contains the Gravity.RIGHT, dialog box appears on the right, so lp.x said offset, relative right negative ignored
         * When the parameter value contains the Gravity.TOP, dialog box appears at the top, so lp.y said offset, relative above negative ignored
         * When the parameter value contains the Gravity.BOTTOM, dialog box appears at the bottom, so lp.y said offset, relatively lower negative values are ignored
         * When the parameter value contains Gravity.CENTER_HORIZONTAL
         * ,Dialog centered horizontally, so lp.x indicates the location of mobile lp.x pixel in the horizontal center, when moving to the right, negative move to the left
         * When the parameter value contains Gravity.CENTER_VERTICAL
         * ,The dialog box vertically, so lp.y said in the position of the mobile lp.y pixels vertically, when moving to the right, negative move to the left
         * The default value for gravity is Gravity.CENTER, Gravity.CENTER_HORIZONTAL |
         * Gravity.CENTER_VERTICAL.
         *
         * The original setGravity parameter values for the Gravity.LEFT | Gravity.TOP dialog should appear in the upper left corner of the program, but in
         * My mobile phone testing found from the left and top have a short distance, and the vertical coordinate the program title bar is also included,
         * Gravity.LEFT, Gravity.TOP, Both Gravity.BOTTOM and Gravity.RIGHT, according to the boundary with a short distance
         */
        lp.x = 100; // The new position of the X coordinates
        lp.y = 100; // The new position of the Y coordinates
        lp.width = 300; // Width
        lp.height = 300; // Height
        lp.alpha = 0.7f; // Transparency

        // The system will call this function when the Window Attributes when the change, can be called directly by application of above the window parameters change, also can use setAttributes
        // dialog.onWindowAttributesChanged(lp);
        dialogWindow.setAttributes(lp);

        /*
         * Will the size of the dialog according to the percentage screen size settings
         */
//        WindowManager m = getWindowManager();
//        Display d = m.getDefaultDisplay(); // Access to the screen width, height
//        WindowManager.LayoutParams p = dialogWindow.getAttributes(); // Gets the current values of the Parameters dialog box
//        p.height = (int) (d.getHeight() * 0.6); // Height is set to screen 0.6
//        p.width = (int) (d.getWidth() * 0.65); // Width is set to screen 0.65
//        dialogWindow.setAttributes(p);

        dialog.show();

    }}
