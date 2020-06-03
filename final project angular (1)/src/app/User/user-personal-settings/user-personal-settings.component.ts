import { Component, OnInit } from '@angular/core';
import {ApplicationUserSittingService} from '../../_service/application-user-sitting.service';
import {Image} from '../../_models/image';
import {ApplicationUser} from '../../_models/application-user';
import {ImageCroppedEvent} from 'ngx-image-cropper';
import {FormBuilder,FormGroup, Validators} from '@angular/forms'
import {ToastrService} from 'ngx-toastr';
@Component({
  selector: 'app-user-personal-settings',
  templateUrl: './user-personal-settings.component.html',
  styleUrls: ['./user-personal-settings.component.css']
})
export class UserPersonalSettingsComponent implements OnInit {
   form:FormGroup;
  constructor(private UserServ:ApplicationUserSittingService,private _formBulider:FormBuilder,private toaster:ToastrService) { }
  User:ApplicationUser= new ApplicationUser();
  imageChangedEvent: any = '';
    croppedImage: string = '';
    id:string="497a2b25-b878-42ed-9554-678ace76fdaa";
    image:Image =new Image();
    fileChangeEvent(event: any): void {
      console.log(event);
        this.imageChangedEvent = event;
    }
    imageCropped(event: ImageCroppedEvent) {
      console.log(event);
        this.croppedImage = event.base64;
    }
    SaveImage(){
     
      if(this.croppedImage.length >1 ){
        this.image.id=this.id;
      
        this.image.Imageurl=this.croppedImage;
       
        this.UserServ.UploadImae(this.image).subscribe(Response => { this.toaster.success("WOW","Ypur Image is Uploaded")},error=>{this.toaster.error("Sorry","Failed to Uploaed Image")});
      }else{
        this.toaster.error("you must choose image","Sorry")
      }
     
    }

  ngOnInit(): void {
    this.form=this._formBulider.group({
      addr:['',[Validators.required,Validators.minLength(7),Validators.maxLength(30)]],
      birth_date:['',[Validators.required]],
      PhoneNumber:['',[Validators.required,Validators.minLength(6),Validators.maxLength(14),Validators.pattern("^[0-9]*$")]],
      Bio:['',[Validators.required,Validators.minLength(10),Validators.maxLength(50)]]
    })

  }
  Save(){
    console.log(this.User);
    if(this.form.valid){
      console.log(JSON.stringify(this.form.value));
      Object.assign(this.User,this.form.value);
      console.log(this.User);
      this.UserServ.UpdateUser(this.User).subscribe(Response=>{console.log(Response)},error =>{console.log(error)});
    }
    
  }


}
