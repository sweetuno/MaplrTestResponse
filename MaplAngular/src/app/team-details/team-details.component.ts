import { Component, OnInit } from '@angular/core';
import { Toast, ToastrService } from 'ngx-toastr';
import { PlayerDetail } from '../shared/player-detail.model';
import { PlayerDetailService } from '../shared/player-detail.service';
import { TeamDetail } from '../shared/team-detail.model';
import { TeamDetailService } from '../shared/team-detail.service';


@Component({
  selector: 'app-team-details',
  templateUrl: './team-details.component.html',
  styles: [
  ]
})
export class TeamDetailsComponent implements OnInit {

  constructor(public service: TeamDetailService, private toastr:ToastrService, public player: PlayerDetailService) { }

  ngOnInit(): void {
  }

  onLoad(year:number){
    this.service.refreshList(year);
  }

  onUpdate(player:PlayerDetail,year:number){
    this.player.putCaptainPlayer(player.id).subscribe(res =>{
      this.toastr.success('Le joueur '+ player.name + ' ' + player.lastName +' à été assigné capitaine','Passage au poste de capitaine')
      this.service.refreshList(year);
    },
    err => { 
      console.log(err) 
    })
    
  }

}
