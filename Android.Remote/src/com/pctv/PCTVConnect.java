package com.pctv;

import android.app.Activity;
import android.os.Bundle;
import android.widget.Button;

public class PCTVConnect extends Activity
{
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        Button connect = (Button)findViewById(R.id.connectButton);
        Button exit = (Button)findViewById(R.id.exitButton);

        //Add listeners for each button

        //Connect to the web service: do this on the UI interface OnClick

        //Exit: do this on the UI interface OnClick
    }
}