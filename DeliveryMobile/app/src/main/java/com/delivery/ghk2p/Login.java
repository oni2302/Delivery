package com.delivery.ghk2p;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.VolleyError;


public class Login extends Fragment {

    EditText edituser,editPassword;
    Button btnLogin;
    ApiHelper apiHelper;


    public Login(){

    }



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        SharedPreferences sharedPreferences =getActivity().getSharedPreferences("Login_Session", Context.MODE_PRIVATE);
        if(!sharedPreferences.equals(null)){
            Fragment Home = new Home();
            FragmentManager fragmentManager =getActivity().getSupportFragmentManager();
            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
            fragmentTransaction.replace(R.id.frame, Home );
            fragmentTransaction.commit();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_login, container, false);
        btnLogin = view.findViewById(R.id.BtnLogin);
        edituser = view.findViewById(R.id.editUser);
        editPassword = view.findViewById(R.id.editPassword);
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                apiHelper = new ApiHelper(getActivity().getApplicationContext(), "dangnhap/?user="+edituser.getText().toString()+"&pass="+editPassword.getText().toString());

                if (edituser.getText().length() !=0 && editPassword.getText().length() != 0 ){
                    apiHelper.getResult(new ApiHelper.GoiHam()
                    {

                        @Override
                        public void LayDuLieu(String ketqua) {
                            if(ketqua.equals("true")){
                                Toast.makeText(getActivity().getApplicationContext(),"Đăng nhập thành công",Toast.LENGTH_LONG).show();
                                SharedPreferences sharedPreferences = getActivity().getSharedPreferences("Login_Session", Context.MODE_PRIVATE);
                                SharedPreferences.Editor editor = sharedPreferences.edit();
                                editor.putString("MY_NAME","");
                                editor.commit();
                                Fragment Home = new Home();
                                FragmentManager fragmentManager =getActivity().getSupportFragmentManager();
                                FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                                fragmentTransaction.replace(R.id.frame, Home );
                                fragmentTransaction.commit();
                            }
                            else {
                                Toast.makeText(getActivity().getApplicationContext(),"Đăng nhập thất bại, vui lòng kiểm tra lại username or password",Toast.LENGTH_LONG).show();

                            }
                        }

                        @Override
                        public void LayLoi(VolleyError loi) {

                        }
                    });
                }
                else {
                    Toast.makeText(getActivity().getApplicationContext(),"Mời bạn nhập đủ thông tin",Toast.LENGTH_LONG).show();

                }

            }
        });
        //Return view :)))) chứ k phải inflater.inflate(R.layout.fragment_login, container, false
        //Ảo chưa
        return view;


    }
}