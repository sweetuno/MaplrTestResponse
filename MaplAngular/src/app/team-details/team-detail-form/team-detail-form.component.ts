import { Component, OnInit } from '@angular/core';
import { TeamDetail } from 'src/app/shared/team-detail.model';
import { TeamDetailService } from 'src/app/shared/team-detail.service';
import { NgForm } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { PlayerDetail } from 'src/app/shared/player-detail.model';
@Component({
  selector: 'app-team-detail-form',
  templateUrl: './team-detail-form.component.html',
  styles: [
  ]
})
export class TeamDetailFormComponent implements OnInit {

  constructor(public service:TeamDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(player:PlayerDetail,year:number){
      this.service.postTeamPlayer(player,year);
      this.service.refreshList(year);
  }

  resetForm(form:NgForm){
    form.form.reset();
  }

}
