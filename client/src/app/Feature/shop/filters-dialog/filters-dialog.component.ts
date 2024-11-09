import { Component, inject } from '@angular/core';
import { ShopService } from '../../../Core/shop.service';
import { MatDivider } from '@angular/material/divider';
import { MatListOption, MatSelectionList } from '@angular/material/list';
import { MatButton } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [MatDivider,
      MatSelectionList,
      MatListOption,
      MatButton,
      CommonModule,
      FormsModule
  ],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {
 
 shopService=inject(ShopService);
private dialogref=inject(MatDialogRef<FiltersDialogComponent>);
data=inject(MAT_DIALOG_DATA);

selectedBrand:string[]=this.data.selectedBrand;
selectedType:string[]=this.data.selectedType;

 constructor(){

 }

 ApplyFilters(){
  this.dialogref.close({ 
    selectedBrand:this.selectedBrand,
    selectedType:this.selectedType
  });
 }

}
