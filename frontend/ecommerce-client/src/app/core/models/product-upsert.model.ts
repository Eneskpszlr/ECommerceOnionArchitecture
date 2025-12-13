export interface ProductUpsert{
    id? : number;
    productName : string;
    unitPrice : number;
    categoryId : number;
}