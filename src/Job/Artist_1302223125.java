/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package Job;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 *
 * @author athal
 */
public class Artist_1302223125 {
    private String Name;
    private String birthDate;
    
    public Artist_1302223125(String name, String birthDate){
        this.setName(name);
        this.setBirthDate(birthDate);
    }

    public String getName() {
        return Name;
    }

    public void setName(String Name) {
        this.Name = Name;
    }

    public String getBirthDate() {
      SimpleDateFormat inputFormat = new SimpleDateFormat("yyyy-MM-dd");
      SimpleDateFormat outputFormat = new SimpleDateFormat("dd MMMM yyyy");
      
     try {
         Date date = inputFormat.parse(this.birthDate);
         return outputFormat.format(date);
      } catch (ParseException var4) {
         return null;
      }
    }

    public void setBirthDate(String birthDate) {
        this.birthDate = birthDate;
    }
    
    public int getAge(){
      SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
      Date BirthDate = null;

       try {
         BirthDate = dateFormat.parse(this.birthDate);
      } catch (ParseException var6) {
         return -1;
      }

      Calendar dob = Calendar.getInstance();
      dob.setTime(BirthDate);
      Calendar today = Calendar.getInstance();
      int age = today.get(1) - dob.get(1);
      if (today.get(2) < dob.get(2) || today.get(2) == dob.get(2) && today.get(5) < dob.get(5)) {
         --age;
      }

      return age;
    }
    
    public void displayInfo(){
      int age = this.getAge();
      String tanggal = this.getBirthDate();
      System.out.println("Artist name : " + this.Name);
      System.out.println("Birthdate   : " + tanggal);
      System.out.println("Age         : " + age);
    }
}

