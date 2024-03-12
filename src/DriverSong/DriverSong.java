/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package DriverSong;

import Art.Song_1302223125;
import Job.Artist_1302223125;

/**
 *
 * @author athal
 */
public class DriverSong {
   public DriverSong(){
   
   }
   
   public static void main(String[] args) {
      Artist_1302223125 a1 = new Artist_1302223125("Alan Walker", "1997-08-24");
      Artist_1302223125 a2 = new Artist_1302223125("Ari Lasso", "1973-01-17");
      System.out.println("Artist Info:");
      a1.displayInfo();
      System.out.println();
      a2.displayInfo();
      System.out.println();
      Song_1302223125 song1 = new Song_1302223125("Not You", a1, "2021-12-03");
      Song_1302223125 song2 = new Song_1302223125("Hampa", a2, "2003-02-10");
      System.out.println("\nSong Info:");
      song1.displayInfo();
      System.out.println();
      song2.displayInfo();
   }
}

