export class Calendar {
    Id?:number;
    vendor_id?:string;
    bookingId?:number;
    busyDay?:Date;
    reason?:string;
    status?:boolean;
    constructor(values:object={}){
        Object.assign(this, values)
    }
}
 