import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PlayerDetail } from '../shared/player-detail.model';
import { PlayerDetailService } from '../shared/player-detail.service';

@Component({
  selector: 'app-player-details',
  templateUrl: './player-details.component.html',
  styles: [
  ]
})
export class PlayerDetailsComponent implements OnInit {

  constructor(public service: PlayerDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:PlayerDetail){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record ?'))
    this.service.deletePlayerDetail(id)
    .subscribe(
      res =>{
        this.service.refreshList();
        this.toastr.error('Deleted succesfully', 'Player Detail')
      },
      err => { console.log(err) }
    )
  }
}
