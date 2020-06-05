import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';


//import {FormGroup, FormControl, FormBuilder} from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './_Account/login/login.component';
import { RegisterComponent } from './_Account/register/register.component';
import { IndexComponent } from './Home/index/index.component';
import { FooterComponent } from './Home/footer/footer.component';
import { NavbarComponent } from './Useable/navbar/navbar.component';
import { HomeComponent } from './Home/home/home.component';
import { ErrorpageComponent } from './errorpage/errorpage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistervendorComponent } from './_Account/registervendor/registervendor.component';
import {UserHomePageComponent} from './Home/user-home-page/user-home-page.component';
import { VendorProfileComponent } from './Vendor/vendor-profile/vendor-profile.component';
import { VendorBookingsComponent } from './Vendor/vendor-bookings/vendor-bookings.component';
import { VendorCalendarComponent } from './Vendor/vendor-calendar/vendor-calendar.component';
import { VendorBudgetComponent } from './Vendor/vendor-budget/vendor-budget.component';
import { VendorPersonalSettingsComponent } from './Vendor/vendor-personal-settings/vendor-personal-settings.component';
import { CategClientsComponent } from './Vendor/categ-clients/categ-clients.component';
import { VendorWorkViewComponent } from './Vendor/vendor-work-view/vendor-work-view.component';
import { VendorCategReviewsComponent } from './Vendor/vendor-categ-reviews/vendor-categ-reviews.component';
import { ClientBookingDetailsComponent } from './Vendor/client-booking-details/client-booking-details.component';
import { VendorHomePageComponent } from './Vendor/Home/vendor-home-page/vendor-home-page.component';
import { VendorIndexComponent } from './Vendor/Home/vendor-index/vendor-index.component';
import { TrafficComponent } from './Vendor/Home/traffic/traffic.component';
import { ClientChatComponent } from './Vendor/client-chat/client-chat.component';
import { ClientMessagesComponent } from './Vendor/client-messages/client-messages.component';
import { FilterSearchComponent } from './Useable/filter-search/filter-search.component';

import { ChatTabComponent } from './Useable/chat-tab/chat-tab.component';
import { EditComponent } from './Useable/edit/edit.component';
import {ChartsModule} from 'ng2-charts'
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { UserPersonalSettingsComponent } from './User/user-personal-settings/user-personal-settings.component';
import { VendorMessagesComponent } from './User/vendor-messages/vendor-messages.component';
import { VendorChatComponent } from './User/vendor-chat/vendor-chat.component';
import { EditBookingComponent } from './Useable/edit-booking/edit-booking.component';
import { LiveChatComponent } from './Useable/live-chat/live-chat.component';
import { ToDoListComponent } from './Useable/to-do-list/to-do-list.component';
import { EditTodoListModalComponent } from './Useable/edit-todo-list-modal/edit-todo-list-modal.component';
import { VendorPackagesComponent } from './Vendor/vendor-packages/vendor-packages.component';

import { PricePlanCardComponent } from './Useable/Summerprice-plan-card/price-plan-card.component';
import{WinterPricePlanCardComponent}  from './Useable/winter-price-plan-card/winter-price-plan-card.component';
import { WeddingPackCardComponent } from './Useable/wedding-pack-card/wedding-pack-card.component';
import { EngagementPackCardComponent } from './Useable/engagement-pack-card/engagement-pack-card.component';
import { SinglePackCardComponent } from './Useable/single-pack-card/single-pack-card.component';

import { ClientCardComponent } from './Useable/client-card/client-card.component';

import { UserBookingComponent } from './User/user-booking/user-booking.component';
import { AllReviewsComponent } from './User/all-reviews/all-reviews.component';
import { ClientBookCatComponent } from './User/client-book-cat/client-book-cat.component';
import { FavoritVendorComponent } from './User/favorit-vendor/favorit-vendor.component';
import { GalleryComponent } from './Home/gallery/gallery.component';
import {UsedGelleryComponent} from './User/used-gellery/used-gellery.component'
import { HttpClientModule ,HttpClient} from '@angular/common/http';
import { TimeagoModule } from 'ngx-timeago';
import { UploadImageComponent } from './Useable/upload-image/upload-image.component';
import {NgxPaginationModule} from 'ngx-pagination';
import{ NgInitDirective} from './User/ng-init-directive'
// admin
import { AdminhomeComponent } from './admin/adminhome/adminhome.component';
import { UserstablesComponent } from './admin/userstables/userstables.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { CatagoriesSessionComponent } from './admin/catagories-session/catagories-session.component';
import { MessagesComponent } from './admin/messages/messages.component';
import { BookingdetailsComponent } from './admin/bookingdetails/bookingdetails.component';
import { TopDataComponent } from './admin/top-data/top-data.component';
import { VendordetailsComponent } from './admin/vendordetails/vendordetails.component';
import { AuthService } from 'angularx-social-login';
import { SocialLoginModule, AuthServiceConfig,GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';
import { BookPackageComponent } from './User/book-package/book-package.component';
import { UserPackageComponent } from './User/user-package/user-package.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { UserroleComponent } from './admin/Roles/userrole/userrole.component';
import { AdminProductsComponent } from './admin/productView/admin-products/admin-products.component';
import { ShowVendorComponent } from './User/show-vendor/show-vendor.component';
import { ShopHomeComponent } from './shop/shop-home/shop-home.component';
import { EditBookComponent } from './User/edit-book/edit-book.component';
 
 
import {UserArticleComponent} from './Articals/article/user-article.component';
import {ArticlesComponent} from './Articals/crudarticles/articles.component';
 
import { ChatComponent } from './chat/chat.component';
  
// import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DatePipe } from '@angular/common';
const google_outh_client_id:string = "707593203866-msqo17ipi5tt4gg72af4hfb4ta4dpge0.apps.googleusercontent.com";
let config= new AuthServiceConfig([{
  id:GoogleLoginProvider.PROVIDER_ID,
  provider:new GoogleLoginProvider(google_outh_client_id)
}])

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    IndexComponent,
    FooterComponent,
    NavbarComponent,
    HomeComponent,
    UsedGelleryComponent,
    ChatTabComponent,
    ErrorpageComponent,
    RegistervendorComponent,
    VendorProfileComponent,
    VendorBookingsComponent,
    VendorCalendarComponent,
    VendorBudgetComponent,
    VendorPersonalSettingsComponent,
    CategClientsComponent,
    VendorWorkViewComponent,
    VendorCategReviewsComponent,
    ClientBookingDetailsComponent,
    VendorHomePageComponent,
    VendorIndexComponent,
    TrafficComponent,
    ClientChatComponent,
    ClientMessagesComponent,
    FilterSearchComponent,
    EditComponent,
    UserProfileComponent,
    UserPersonalSettingsComponent,
    VendorMessagesComponent,
    VendorChatComponent,
    EditBookingComponent,
    LiveChatComponent,
    ToDoListComponent,
    EditTodoListModalComponent,
    VendorPackagesComponent,
    PricePlanCardComponent,
    WinterPricePlanCardComponent,
    WeddingPackCardComponent,
    EngagementPackCardComponent,
    SinglePackCardComponent,
    UserArticleComponent,
    ClientCardComponent,
    UserBookingComponent,
    AllReviewsComponent,
    ClientBookCatComponent,
    FavoritVendorComponent,
    GalleryComponent,
    EditTodoListModalComponent,
    UploadImageComponent,
    NgInitDirective,
    // admin
    ShowVendorComponent,
    AdminhomeComponent,
    UserstablesComponent,
    DashboardComponent,
    CatagoriesSessionComponent,
    MessagesComponent,
    BookingdetailsComponent,
    TopDataComponent,
    VendordetailsComponent,
    BookPackageComponent,
    UserPackageComponent,
    UserroleComponent,
    AdminProductsComponent,
    EditBookComponent,
 
    ShopHomeComponent
    
 

    ArticlesComponent,
    UserHomePageComponent,
 
    ChatComponent,
 
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    ImageCropperModule,
    HttpClientModule, TimeagoModule.forRoot(),
    ChartsModule,
    NgxPaginationModule,
    // NgbModule,
    SocialLoginModule.initialize(config),
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot() // ToastrModule added
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
