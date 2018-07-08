import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, NavigationStart } from '@angular/router';

/** Fenêtre pop-in */
@Component({
  selector: 'layout-popin',
  templateUrl: './popin.cpn.html',
  styleUrls: ['./popin.cpn.less']
})
export class LayoutPopinComponent implements OnInit {

  public ngOnInit(): void {
  }

}
