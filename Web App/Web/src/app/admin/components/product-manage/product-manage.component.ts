import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { AdminService } from '../../services/admin.services';
import { ProductModel } from '../../models/product.model';
import { HttpErrorResponse } from '@angular/common/http';
import { ThemePalette } from '@angular/material/core';
import { KeywordModel } from '../../models/keyword.model';
import { KeywordResponseModel } from '../../models/keyword-response.model';

@Component({
  selector: 'app-product-manage',
  templateUrl: './product-manage.component.html',
  styleUrls: ['./product-manage.component.css']
})


export class ProductManageComponent implements OnInit {

  product: ProductModel;
  products: ProductModel[];
  keywords: KeywordResponseModel[];
  keywordsForChips: KeywordResponseModel[];
  availableColors: ChipColor[] = [
    // {name: 'none', color: undefined},
    // { name: 'Primary', color: 'primary' },
    { name: 'Accent', color: 'accent' },
    { name: 'Warn', color: 'warn' }
  ];
  value = 'Add new keyword';


  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;





  constructor(private _adminService: AdminService) {

    this.products = [];
    this.keywords = [];
    this.keywordsForChips = [];
    this.product = new ProductModel();


  }

  ngOnInit(): void {

    this.loadKeywords();
    this.loadProducts();
  }


  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    // Add our fruit
    if (value) {

      let kwc: KeywordResponseModel = new KeywordResponseModel();
      kwc.keywordCode = '';
      kwc.keywordId = 0;
      kwc.keywordName = value;

      this.keywordsForChips.push(kwc);
      console.log('adddd');
    }

    // Clear the input value
    event.chipInput!.clear();

    if (value.length > 0)
      this.loadProductsByKeywords();
  }

  remove(kwc: KeywordResponseModel): void {
    const index = this.keywordsForChips.indexOf(kwc);

    if (index >= 0) {
      this.keywordsForChips.splice(index, 1);
    }

    if (this.keywordsForChips.length == 0)
      this.loadProducts();
    else
      this.loadProductsByKeywords();
  }

  getKeywordName(keywordId: number) {

    var obj = this.keywords.find(k => k.keywordId == keywordId);
    if (obj)
      return obj.keywordName;
    else
      return "";
  }


  loadKeywords() {

    this.keywordsForChips = [];
    this._adminService.Get_Keywords().subscribe(response => {
      this.keywords = response;

      //this.keywordsForChips = this.keywords;
      this.keywords.map(k => {
        // this.keywordsForChips.push(k);
      });
    },
      errorResponse => {
        this.handleError(errorResponse);
      });
  }


  clearKwChips() {
    this.keywordsForChips = [];
    this.loadProducts();

  }


  loadProducts() {

    this._adminService.Get_Products().subscribe(response => {
      this.products = response;
    },
      errorResponse => {
        this.handleError(errorResponse);
      });
  }


  loadProductsByKeywords() {

    let keywordIds: number[] = [];
    this.keywordsForChips.map(kc => {
      let kid: any = this.keywords.find(k => k.keywordName == kc.keywordName)?.keywordId;
      if (kid)
        keywordIds.push(kid);
    });

    if (keywordIds.length > 0) {
      this._adminService.Get_ProductsByKeywords(keywordIds).subscribe(response => {
        this.products = response;
      },
        errorResponse => {
          this.handleError(errorResponse);
        });
    }
    else {
      this.products = [];
    }
  }


  loadAProduct(product: ProductModel) {

    this._adminService.Get_Product(product).subscribe(response => {
      this.product = response;
    },
      errorResponse => {
        this.handleError(errorResponse);
      });

  }


  refreshProductsModel(product: ProductModel) {
    this._adminService.Get_Product(product).subscribe(response => {
      this.product = response;
      this.products.map(p => {
        if (p.productId == product.productId) {
          p = product;
        }
      })


    },
      errorResponse => {
        this.handleError(errorResponse);
      });
  }


  addKeyword(product: ProductModel) {

    this._adminService.Add_Keyword(product).subscribe(response => {
      this.loadKeywords();
      this.loadProducts();
      //this.refreshProductsModel(product);
    },
      errorResponse => {
        this.handleError(errorResponse);
      });

  }



  deleteKeyword(product: ProductModel, keyword: KeywordModel) {

    this._adminService.Delete_Keyword(product, keyword).subscribe(response => {
      this.loadKeywords();
      this.loadProducts();
      //this.refreshProductsModel(product);
    },
      errorResponse => {
        this.handleError(errorResponse);
      });

  }


  editKeyword(product: ProductModel, keyword: KeywordModel) {

    product.isEditMode = true;
    product.keyword = this.getKeywordName(keyword.keywordId);

    product.productKeywords.map(pk => {
      pk.isEditMode = false;
      if (pk.productKeywordsId == keyword.productKeywordsId) {
        pk.isEditMode = true;
      }
    })

  }


  updateKeyword(product: ProductModel) {

    let productKeywordsIdToUpdate: number = -1;

    product.productKeywords.map(pk => {
      if (pk.isEditMode == true) {
        productKeywordsIdToUpdate = pk.keywordId;
      }
    });

    this._adminService.Update_Keyword(product, productKeywordsIdToUpdate).subscribe(response => {
      this.loadKeywords();
      this.loadProducts();
      //this.refreshProductsModel(product);
    },
      errorResponse => {
        this.handleError(errorResponse);
      });


  }



  //Handle Service Error
  //Logs Front End Error if Error generated from A client-side or network error occurred
  //Logs Back End Error if Error generated The backend returned an unsuccessful response code
  //Returns : None
  private handleError(error: HttpErrorResponse) {
    let logAction: string = "";
    let logDescription: string = "";
    if (error.error instanceof ErrorEvent) {
      logAction = "error ";
      logDescription = error.error.message;
    } else {
      logAction = "error ";
      logDescription = JSON.stringify(error.error);
    }
    console.log(logDescription);
  }



}


export interface ChipColor {
  name: string;
  color: ThemePalette;
}


export interface Fruit {
  name: string;
}




