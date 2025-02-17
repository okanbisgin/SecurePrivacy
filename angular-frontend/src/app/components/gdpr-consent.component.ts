import { Component } from '@angular/core';

@Component({
  selector: 'app-gdpr-consent',
  templateUrl: './gdpr-consent.component.html',
  styleUrls: ['./gdpr-consent.component.css']
})
export class GdprConsentComponent {
  showConsent: boolean = !localStorage.getItem('gdprConsent');

  acceptConsent() {
    localStorage.setItem('gdprConsent', 'true');
    this.showConsent = false;
  }
}
