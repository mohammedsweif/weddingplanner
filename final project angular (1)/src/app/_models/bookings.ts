export class Bookings {
    constructor(){}
     BookingId:number;
     BookDate:Date;
     RealDate:Date;
     CategoryId:number;
     Status:BinaryType;
     Cost:number;
     UserId:string;
     vendorId:string;
     pack_id:number;
 }
 export class GetBooking{
    constructor(){}
    bookDate:Date;
    id:number;
    category:string;
    cost:number;
    realDate:Date;
    status:boolean;
    vendorname:string;
}