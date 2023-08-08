import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApinampilService } from '../Services/apinampil.service';
import { Porto } from '../Model/Porto';
import { Observable, Subscriber } from 'rxjs';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  portofolioId: number | null = null;
  edit: Porto | null = null;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApinampilService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.portofolioId = +params['id'];
      if (this.portofolioId !== null) {
        this.loadPortofolio(this.portofolioId);
      }
    });
  }

  loadPortofolio(id: number): void {
    this.apiService.ambilById(id).subscribe((portofolio: Porto) => {
      if (portofolio) {
        this.edit = portofolio;
      }
    });
  }

  onSubmit(): void {
    if (this.portofolioId !== null && this.edit !== null) {

      this.apiService
        .updatePortofolio(this.portofolioId, this.edit)
        .subscribe((response) => {
          this.router.navigate(['/portofolio']);
        });
    }
  }

  myImage!: Observable<any>;

  base64code!: any;

  onChange = ($event : Event)  => {
    const target = $event.target as HTMLInputElement;
    const file: File = (target.files as FileList)[0];
    console.log(file);

    this.convertToBase64(file)
  }

  convertToBase64(file: File){
    const observable = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber)
    });

    observable.subscribe((d) => {
      if(this.edit != null){
        this.edit.foto = d;
        this.myImage = d;
      }
    });
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);
    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    }
    filereader.onerror = () => {
      subscriber.error();
      subscriber.complete();
    }
  }
}
