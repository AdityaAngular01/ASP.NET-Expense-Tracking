import { Component } from '@angular/core';
import {errorMessageColor} from '../../constants/styles';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-error-message',
  imports: [NgClass],
  templateUrl: './error-message.html',
  styleUrl: './error-message.css',
})
export class ErrorMessage {
  errorMessageColor: string = errorMessageColor;
}
