package com.mc2techservices.kidsreaderleapfroglearntoread.supportcode;


import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;

public class AppSpecific {
	public static String gloUUID;
	public static String gloxmlns;
	public static String gloWebServiceURL;
	public static String gloPackageName;
	public static String gloLD;
	public static String gloPD;
	public static String gloWebURL;

	public static String gloDefaultReadMode;
	public static String gloShowSettings;
	public static int gloTextSize;
	public static int gloWordPadding;
	public static int gloTTSSpeed;
	public static int gloTTSPitch;


	public static void AlertPasswordMismatch(Context c) {
		DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dialog, int which) {
				switch (which){
					case DialogInterface.BUTTON_POSITIVE:
						break;
				}
			}
		};
		AlertDialog.Builder builder = new AlertDialog.Builder(c);
		builder.setMessage("The password / confrim password you entered didn't match.").setPositiveButton("Oops", dialogClickListener).show();
	}
	public static String UnEncodeText(String pTextIn) {
		String pRewrite=pTextIn.replace("<newkrline>", "\n");
		pRewrite=pRewrite.replace("encquot", "'");
		return  pRewrite;
	}

	public static String EncodeText(String pTextIn) {
		String pRewrite=pTextIn.replace("\n","<newkrline>");
		pRewrite=pRewrite.replace("'","encquot" );
		return  pRewrite;
	}
}