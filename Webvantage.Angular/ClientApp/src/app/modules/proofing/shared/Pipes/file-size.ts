import { Pipe, PipeTransform } from '@angular/core';
/*
*/
@Pipe({ name: 'FileSize' })
export class FileSizePipe implements PipeTransform {
  transform(value: number): string {
    var i = Math.floor(Math.log(value) / Math.log(1024));
    return (value / Math.pow(1024, i)).toFixed(2) + ' ' + ['B', 'kB', 'MB', 'GB', 'TB'][i] + ' (' + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + ' bytes)';
  }
}
