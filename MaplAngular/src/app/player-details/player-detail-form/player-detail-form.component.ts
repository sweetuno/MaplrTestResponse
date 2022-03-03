import { Component, OnInit } from '@angular/core';
import { PlayerDetail } from 'src/app/shared/player-detail.model';
import { PlayerDetailService } from 'src/app/shared/player-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-player-detail-form',
  templateUrl: './player-detail-form.component.html',
  styles: [
  ]
})

export class PlayerDetailFormComponent implements OnInit {

  constructor(public service:PlayerDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id==0){
      this.insertRecord(form);
    }else{
      this.updateRecords(form);
    }
  }

  insertRecord(form: NgForm){
    this.service.postPlayerDetail().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Submitted succesfully', 'Player detail')
      },
      err => {console.log(err);}
    );
  }

  updateRecords(form:NgForm){
    this.service.putPlayerDetail().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Updated succesfully', 'Player detail')
      },
      err => {console.log(err);}
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new PlayerDetail();
  }
}
