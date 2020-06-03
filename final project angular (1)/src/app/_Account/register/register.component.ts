import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Registerr } from 'src/app/_Models/Register';
import { RegisterVendor } from 'src/app/_Models/RegisterVendor';
import { RegisterServiceService } from 'src/app/_service/register-service.service';
 

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
checkclass=1;
changestyle(){
  if(this.checkclass == 1){
    this.checkclass = 2;
  }else{
    this.checkclass = 1;
  }
}
 constructor(private fb:FormBuilder,private ser:RegisterServiceService) { }
 userForm:FormGroup;
 massageValidator={
  UserName:{
    required:"this fild must be enter",
    minLength:"you should enter at least 15 char",
    maxlength:"you should enter less than 150 char"
  },
  Email:{
    required:"this fild must be enter and be email"

  },
  Password:{
    required:"this fild must be enter",
    minLength:"you should enter at least 6"


  },
  ConfirmPassword:{
    required:"this fild must be enter",
    minLength:"you should enter at least 6"

  } }
  /****************************************************** */
 message:string;
 success="please check your Email now to confirm";
 regist:Registerr;
 register(){
   if(this.checkclass==1){
if(this.userForm.valid){
  this.completeregisterobject();
this.ser.register(this.regist).subscribe(success =>{
  
  this.message =String(this.success);
  console.log(this.message ,this.success);

  this.userForm.reset();
},err=>{
  this.message =err.error;
  
});
if(this.message == ""){
  this.message =String(this.success);
}
}else{
  alert("no there is an error in your data ");
}
console.log(this.regist);}
else{
 
}
}
/******************************************************** */
completeregisterobject(){
  this.regist.UserName = this.userForm.value.UserName;
  this.regist.Email = this.userForm.value.Email;
  this.regist.Password = this.userForm.value.Password;
  this.regist.ConfirmPassword = this.userForm.value.ConfirmPassword;

}
checkpassandconfirm(){
  if(this.userForm.value.Password !== '' && this.userForm.value.ConfirmPassword !== '')
  {if(this.userForm.value.Password !== this.userForm.value.ConfirmPassword)
      { return false;}}
  return true;
}
/*********************************************************************** */
registerve(){
this.ser.registerven(this.registervendor).subscribe(suc=>{
  console.log("done");
},err=>{
  console.log("erroerr");
})
}
 registervendor:RegisterVendor;
 checkpassandconfirmvendor():boolean{
   if(this.registervendor.Password !="" && this.registervendor.ConfirmPassword !=""){
if(this.registervendor.Password !=  this.registervendor.ConfirmPassword){
  return true;
}
   }
   return false;
 }
  ngOnInit(): void {
    this.registervendor={
      UserName:"",
      Email:"",
      Password:"",
      ConfirmPassword:"",
      address:"",
      birth_date:null
    }
   this. message='';
   this. regist={
      UserName:"",
      Email:"",
      Password:"",
      ConfirmPassword:""
    }
    this.userForm=this.fb.group({
    UserName:["",[Validators.required,Validators.minLength(15),Validators.maxLength(150)]],
    Email:["",[Validators.required,Validators.email]],
    Password:["",[Validators.required,Validators.minLength(6)]],
    ConfirmPassword:["",[Validators.required,Validators.minLength(6)]],
    

    });
    
  }

}
