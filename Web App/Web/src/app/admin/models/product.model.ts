import { KeywordModel } from "./keyword.model";

export class ProductModel {

    productId: number;
    productCode: string;
    productName: string;
    isActive: boolean;
    productKeywords: KeywordModel[]; 

    keyword: string;
    isEditMode: boolean;

    constructor() {
        this.keyword = "Add new keyword";
        this.isEditMode = false;
        this.productId = 0;
        this.productCode = "";
        this.productName = "";
        this.isActive = false;
        this.productKeywords = []; 
    }
}

 