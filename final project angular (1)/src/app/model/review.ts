import { Reviewreplay } from './reviewreplay';

export class Review {
    public  User_Id?:string;
      public  Vendor_Id?:string;
      public  Comment?:string;
      public  catagory_id?:Number;
      public  username?:string;
      public  vendorname?:string;
      public  catname?:string;
      public  PostDate?:Date;
      public  ID?:Number;
      public liked?:boolean;
      public  replies:Reviewreplay[];
      public user:string  
}
