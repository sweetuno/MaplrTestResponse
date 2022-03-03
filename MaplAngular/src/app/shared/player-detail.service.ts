import { Injectable } from '@angular/core';
import { PlayerDetail } from './player-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class PlayerDetailService {

  constructor(private http:HttpClient) { }


  formData:PlayerDetail = new PlayerDetail();
  list:PlayerDetail[];

  readonly baseURL = 'https://localhost:44348/api/Player'

  postPlayerDetail(){
    return this.http.post(this.baseURL,this.formData);
  }

  putPlayerDetail(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`,this.formData)
  }

  refreshList(){
    this.http.get(this.baseURL).toPromise().then(res=> this.list = res as PlayerDetail[])
  }

  deletePlayerDetail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  putCaptainPlayer(id:number){
    return this.http.put(`${this.baseURL}/${id}/Captain`,'')
  }
}
