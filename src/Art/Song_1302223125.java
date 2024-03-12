/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package Art;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import Job.Artist_1302223125;
/**
 *
 * @author athal
 */
public class Song_1302223125 {
    private String title;
    private Artist_1302223125 artist;
    private String relase;

    public Song_1302223125(String title, Artist_1302223125 artist, String relase){
       this.setTitle(title);
      this.setArtist(artist);
      this.setRelase(relase);
    }
    
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public Artist_1302223125 getArtist() {
        return artist;
    }

    public void setArtist(Artist_1302223125 artist) {
        this.artist = artist;
    }

    public String getRelase() {
      SimpleDateFormat inputFormat = new SimpleDateFormat("yyyy-MM-dd");
      SimpleDateFormat outputFormat = new SimpleDateFormat("dd MMMM yyyy");

      try {
         Date date = inputFormat.parse(this.relase);
         return outputFormat.format(date);
      } catch (ParseException var4) {
         var4.printStackTrace();
         return "";
      }
    }

    public void setRelase(String relase) {
        this.relase = relase;
    }
    
       public int getAge() {
      SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
      Date birthDate = null;

     try {
         birthDate = dateFormat.parse(this.relase);
      } catch (ParseException var6) {
         var6.printStackTrace();
         return -1;
      }

      Calendar dob = Calendar.getInstance();
      dob.setTime(birthDate);
      Calendar today = Calendar.getInstance();
      int age = today.get(1) - dob.get(1);
      if (today.get(2) < dob.get(2) || today.get(2) == dob.get(2) && today.get(5) < dob.get(5)) {
         --age;
      }

      return age;
   }

    public void displayInfo(){
      String rilis = this.getRelase();
      int artistAge = this.artist.getAge() - this.getAge();
      System.out.println("Title   : " + this.title);
      System.out.println("Artist  : " + this.artist.getName());
      System.out.println("Release : " + rilis);
      System.out.println("Artist age is " + artistAge + " when song released");
    }
}
