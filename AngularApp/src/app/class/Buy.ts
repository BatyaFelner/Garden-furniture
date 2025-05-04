import { Product } from "./product";
import { PurchaseDetails } from "./PurchaseDetail";

export class Buy{
    constructor(public id:number=0,
    public codeClient ?:string , 
    public date?:Date 
    ,public sumPrice:number=0 ,
    public sumCount:number=0
    ,public note ?:string 
     , public clientName?:string, public purchaseDetails:Array<Product>=new Array<Product>()){}
}