export class KeywordModel {

    productKeywordsId: number;
    productId: number;
    keywordId: number;
    isActive: boolean; 
    
    isEditMode: boolean;

    constructor() {
        this.isEditMode = false;
        this.productKeywordsId = 0;
        this.productId = 0;
        this.keywordId = 0;
        this.isActive = false;
 
    }
}

 