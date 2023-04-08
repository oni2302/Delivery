package com.delivery.ghk2p;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.WindowManager;
import android.widget.TextView;
import android.widget.Toast;
import com.android.volley.VolleyError;

import java.util.Objects;

public class MainActivity extends AppCompatActivity {
    TextView textView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Objects.requireNonNull(getSupportActionBar()).hide();
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_main);


        //Cách dùng ApiHelper
        textView = findViewById(R.id.textView);


//        String action = "alo";
//        ApiHelper api = new ApiHelper(MainActivity.this,action);
//
//        api.getResult(new ApiHelper.GoiHam() {
//            @Override
//            public void LayDuLieu(String ketqua) {
//                textView.setText(ketqua);
//            }
//
//            @Override
//            public void LayLoi(VolleyError loi) {
//                textView.setText(loi.toString());
//            }
//        });
    }
}