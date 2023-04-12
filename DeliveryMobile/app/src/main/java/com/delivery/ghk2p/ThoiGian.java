package com.delivery.ghk2p;

import java.util.Date;

public class ThoiGian {
    public static double SoSanhNgayVoiHienTai(long time){
        time = new Date().getTime()-time;
        return (double) time/1000/3600/24;
    }
}
