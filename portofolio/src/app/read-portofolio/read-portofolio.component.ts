import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Porto } from '../Model/Porto';
import { ApinampilService } from '../Services/apinampil.service';

@Component({
  selector: 'app-read-portofolio',
  templateUrl: './read-portofolio.component.html',
  styleUrls: ['./read-portofolio.component.css']
})
export class ReadPortofolioComponent implements OnInit {
  portofolio: Porto | undefined;

  constructor(private apinampilService: ApinampilService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.apinampilService.ambilById(parseInt(id)).subscribe((result: Porto) => {
        this.portofolio = result;
      });
    }
  }
}
