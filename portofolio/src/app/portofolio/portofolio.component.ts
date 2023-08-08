import { Component,OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Porto } from '../Model/Porto';
import { ApinampilService } from '../Services/apinampil.service';

@Component({
  selector: 'app-portofolio',
  templateUrl: './portofolio.component.html',
  styleUrls: ['./portofolio.component.css']
})
export class PortofolioComponent implements OnInit {
  nampilkan: Porto[] = [];

  constructor(public auth: AuthService, private router: Router,private ApinampilService:ApinampilService,private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.auth.checkLoginStatus();
    this.ApinampilService.ambils().subscribe((result: Porto[])=>(this.nampilkan = result));
  }

  logout() {
    this.auth.signout();
    this.navigateToLogin();
  }

  private navigateToLogin() {
    this.router.navigate(['login']); 
  }
}





