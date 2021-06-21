
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { ProductModel } from '../models/product.model';
import { KeywordModel } from '../models/keyword.model';
import { KeywordResponseModel } from '../models/keyword-response.model';


@Injectable({
    providedIn: 'root'
})
export class AdminService {

    constructor(private httpClient: HttpClient) {

    }


    Get_Products(): Observable<ProductModel[]> {

        return this.httpClient.get<ProductModel[]>(
            environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.getProductsAll,
            {});

    }


    Get_ProductsByKeywords(keys: number[]): Observable<ProductModel[]> {

        return this.httpClient.post<ProductModel[]>(
            environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.getProductByKeywords,
            {
                "keywordids": keys
            });

    }



    Get_Product(productModel: ProductModel): Observable<ProductModel> {

        return this.httpClient.post<any>(
            environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.getProduct,
            {
                "productid": productModel.productId
            });

    }


    Get_Keywords(): Observable<KeywordResponseModel[]> {

        return this.httpClient.get<KeywordResponseModel[]>(
            environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.getKeywordsAll,
            {});

    }


    Add_Keyword(productModel: ProductModel): Observable<any> {

        return this.httpClient.post<ProductModel>(environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.addKeyword,
            productModel);
    }


    Delete_Keyword(productModel: ProductModel, productKeyword: KeywordModel): Observable<any> {

        return this.httpClient.request('DELETE', environment.endPoints.Admin.baseUrl +
        environment.endPoints.Admin.deleteKeyword, {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            }),
            body: {
                "productid": productModel.productId,
                "keywordid": productKeyword.keywordId
            }
        });
    }


    Update_Keyword(productModel: ProductModel, productKeywordIdToUpdate: number): Observable<any> {

        return this.httpClient.post<ProductModel>(environment.endPoints.Admin.baseUrl +
            environment.endPoints.Admin.updateKeyword,
            {
                "productid": productModel.productId,
                "keywordid": productKeywordIdToUpdate,
                "keyword": productModel.keyword
            });
    }

 


}

