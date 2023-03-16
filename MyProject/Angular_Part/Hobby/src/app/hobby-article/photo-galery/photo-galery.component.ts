import { IPhoto } from './../../shared/interfaces/photo';
import { Component, Input } from '@angular/core';
import { Lightbox } from 'ngx-lightbox';

@Component({
  selector: 'app-photo-galery',
  templateUrl: './photo-galery.component.html',
  styleUrls: ['./photo-galery.component.css']
})
export class PhotoGaleryComponent {
  _albums: any = [];
  @Input() photos?: IPhoto[];
  
  constructor(private _lightbox: Lightbox){
    console.log(this.photos);
     this.photos?.forEach(p=>this._albums.push(p))
 }

  open(index: number): void {
    this._lightbox.open(this._albums, index);
  }

  close(): void {
    this._lightbox.close();
  }
}
