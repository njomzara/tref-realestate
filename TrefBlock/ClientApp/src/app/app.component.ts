import { Component, ViewChild } from '@angular/core';
import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { Options } from 'ngx-google-places-autocomplete/objects/options/options';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'ClientApp';


  options = {
    componentRestrictions: { country: "RS" },
    fields: ["address_components", "name", "place_id", "geometry", "type"],
    types: ["address"],
  } as Options;

  @ViewChild("placesRef") placesRef?: GooglePlaceDirective;


  public handleAddressChange(address: Address) {

    console.log(address);
  }


}
