import { Injectable } from '@angular/core';
import { TeamDetail } from './team-detail.model';
import { HttpClient } from '@angular/common/http'
import { PlayerDetail } from './player-detail.model';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class TeamDetailService {
 
  constructor(private http:HttpClient, private toastr:ToastrService) { }

  // Déclaration
  formData:TeamDetail = new TeamDetail();
  list:TeamDetail[];
  player:PlayerDetail = new PlayerDetail();
  readonly baseURL = 'https://localhost:44348/api/Team'

  // Post du nouveau joueur dans l'équipe
  postTeamPlayer(player:PlayerDetail,year:number){
    return this.http.post(`${this.baseURL}/${year}`,player).subscribe(res =>{
      this.toastr.success('Le joueur '+ player.name + ' ' + player.lastName +' à été ajouté','Ajouter à l\'équipe')
      this.refreshList(year);
    },
    err => { 
      console.log(err) 
    });
  }

  // Rafraichissement de la vue
  refreshList(year:number){
    this.http.get(`${this.baseURL}/${year}`).toPromise().then(res=> this.list = Array.of(res) as TeamDetail[])
  }
}
