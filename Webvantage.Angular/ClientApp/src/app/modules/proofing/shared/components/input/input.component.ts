import { Component, Input, ViewEncapsulation, forwardRef, HostBinding, ChangeDetectorRef, } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'proof-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true
    }
  ]
})
export class InputComponent implements ControlValueAccessor {

  onChange: any = () => { }
  onTouch: any = () => { }

  writeValue(obj: any): void {
    console.log(obj);
    this.text = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouch = fn
  }
  setDisabledState?(isDisabled: boolean): void {
      throw new Error('Method not implemented.');
  }

  set value(val) {  // this value is updated by programmatic changes
    if (val !== undefined && this.text !== val) {
      this.text = val;
      this.onChange(val);
      this.onTouch(val);
    }
  }

  @Input() public placeholder: string;
  public text = '';
}
