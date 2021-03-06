import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Home/home/home.component';
 

import { ErrorpageComponent } from './errorpage/errorpage.component';
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
import { TrafficComponent } from './Vendor/Home/traffic/traffic.component';
import { ClientChatComponent } from './Vendor/client-chat/client-chat.component';
import { ClientMessagesComponent } from './Vendor/client-messages/client-messages.component';
import { GoogleMapComponent } from './Useable/google-map/google-map.component';
import { VendorPackagesComponent } from './Vendor/vendor-packages/vendor-packages.component';
import {UserProfileComponent} from './User/user-profile/user-profile.component';
import {VendorMessagesComponent} from './User/vendor-messages/vendor-messages.component';
import {VendorChatComponent} from './User/vendor-chat/vendor-chat.component';
import{AllReviewsComponent} from './User/all-reviews/all-reviews.component';
import {UserBookingComponent} from './User/user-booking/user-booking.component';
import {FavoritVendorComponent} from './User/favorit-vendor/favorit-vendor.component';
import {ClientBookCatComponent} from './User/client-book-cat/client-book-cat.component';
import {GalleryComponent} from './Home/gallery/gallery.component'
import { EditComponent } from './Useable/edit/edit.component';
import {UserPersonalSettingsComponent} from './User/user-personal-settings/user-personal-settings.component';
import {UserPackageComponent} from './User/user-package/user-package.component';
import {BookPackageComponent} from './User/book-package/book-package.component';
import { AdminhomeComponent } from './admin/adminhome/adminhome.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { CatagoriesSessionComponent } from './admin/catagories-session/catagories-session.component';
import { MessagesComponent } from './admin/messages/messages.component';
import { BookingdetailsComponent } from './admin/bookingdetails/bookingdetails.component';
import { TopDataComponent } from './admin/top-data/top-data.component';
import { VendordetailsComponent } from './admin/vendordetails/vendordetails.component';
import { UserFavouriteComponent } from './User/user-favourite/user-favourite.component';
import{EditBookComponent} from './User/edit-book/edit-book.component';
import { VendorRolesComponent } from './admin/Roles/vendor-roles/vendor-roles.component';
import { UserroleComponent } from './admin/Roles/userrole/userrole.component';
import { UsedGelleryComponent } from './User/used-gellery/used-gellery.component';
import { ProductsComponent } from './shop/products/products.component';
import {UserArticleComponent} from './Articals/article/user-article.component';
import {ArticlesComponent} from './Articals/crudarticles/articles.component';
import { AdminProductsComponent } from './admin/productView/admin-products/admin-products.component';
import { ShowVendorComponent } from './User/show-vendor/show-vendor.component'; 
import { ShopHomeComponent } from './shop/shop-home/shop-home.component';
//////admin
 
 
import {UserHomePageComponent} from './Home/user-home-page/user-home-page.component';
 
import { UserstablesComponent } from './admin/userstables/userstables.component';
import { ChatComponent } from './chat/chat.component';
import { LoginComponent } from './_Account/login/login.component';
import { RegisterComponent } from './_Account/register/register.component';
import { UserguardGuard } from './gaurd/userguard.guard';
import { VendorguardGuard } from './gaurd/vendorguard.guard';
import { AdminguardGuard } from './gaurd/adminguard.guard';
 

import{CartComponent} from './shop/cart/cart.component'
import { ShowProductComponent } from './shop/show-product/show-product.component';
import { ArticalDetailsComponent } from './Articals/artical-details/artical-details.component';
const routes: Routes = [
  {path:"chat",component:ChatComponent},
  {path:"Home",component: HomeComponent}, 
  {path:"Login",component:LoginComponent},
  {path:"Register",component:RegisterComponent},
                            // Login  --Nevine
   
  {path:"Maps",component:GoogleMapComponent} ,
 
  {path:"Vendor",component: VendorProfileComponent,canActivate:[VendorguardGuard],
  
  children:[
  {path:"Messages",component: ClientMessagesComponent,children:[
    {path:"Chat/:id",component:ClientChatComponent},         //**Nevine: router-link:Messages/message_id  //can be reused in other sectios
 
    {path:"",component:ClientChatComponent,pathMatch:"full"}  //*****http://localhost:4200/Vendor/3/Messages/3/Chat/1
                                                              //or** http://localhost:4200/Vendor/3/Messages/3
]} ,  
// {path:"BookingDetails/:id",component:BookingdetailsComponent},
{path:"edit/:id",component:EditComponent},
 
 {path:"Packages",component:VendorPackagesComponent},
  {path:"VendorSettings",component: VendorPersonalSettingsComponent}, 
  {path:"VendorBooking",component: VendorBookingsComponent},          
  {path:"VendorCalendar",component: VendorCalendarComponent},         
  {path:"VendorBudget",component: VendorBudgetComponent},        
  {path:"VendorClients",component: CategClientsComponent},
  {path:"VendorReviews",component: VendorCategReviewsComponent},      
  {path:"BookingDetails/:id",component: ClientBookingDetailsComponent} ,
  {path:"Work",component: VendorWorkViewComponent},
  {path:"Map",component:GoogleMapComponent},
 
  {path:"",component:TrafficComponent,pathMatch:"full"}

]}, 
  
 {path:"User",component:UserProfileComponent,canActivate:[UserguardGuard],children:[
  {path:"Message/:id",component:VendorMessagesComponent ,children:[
    {path:"Chat/:id",component:VendorChatComponent},
    
  ]},  
  {path:"UsedGallery",component:UsedGelleryComponent},
  {path:"ChatVendor/:id" ,component:VendorChatComponent},
  {path:"Booking",component:UserBookingComponent},
  {path:"UserFavorit",component:UserFavouriteComponent},   
  {path:"Reviews",component:AllReviewsComponent},
  {path:"FavouriteVendor" ,component:FavoritVendorComponent},
  {path:"ClientBook", component:ClientBookCatComponent},
  {path:"MySetting",component:UserPersonalSettingsComponent},
  {path:"Showvendor/:id",component:ShowVendorComponent},
  {path:"VendorPackages/:id",component:UserPackageComponent},
  {path:"BookPackage/:id",component:BookPackageComponent},
  {path:"EditBooks/:id",component:EditBookComponent}, 
]}, 

 
{path:"Shop",component:ShopHomeComponent},
 
 
{path:"Admin",component:AdminhomeComponent,canActivate:[AdminguardGuard],children:[
{path:"product",component:AdminProductsComponent},
{path:"usertables",component:UserstablesComponent},////http://localhost:4200/Admin/usertables
{path:"dashboard",component:DashboardComponent},////http://localhost:4200/Admin/:3/dashboard***********
{path:"catagoriessession",component:CatagoriesSessionComponent}, ////http://localhost:4200/Admin/catagoriessession
  {path:"Messages",component:MessagesComponent},////http://localhost:4200/Admin/:3/Messages**************
  {path:"bookingdetails",component:BookingdetailsComponent},////http://localhost:4200/Admin/bookingdetails
  {path:"topdata",component:TopDataComponent},////http://localhost:4200/Admin/:3/topdata 
  {path:"vendordetails",component:VendordetailsComponent},////http://localhost:4200/Admin/:3/vendordetails
  
 
 
{path:"ArticalsOP",component:ArticlesComponent},
 
{path:"vendorrole",component:VendorRolesComponent}//http://localhost:4200/Admin/3/vendorrole
,{path:"userole",component:UserroleComponent}


]},
{path:"ShopHome",component:ShopHomeComponent},
{path:"ProductDetails/:id",component:ShowProductComponent},
{path:"Cart",component:CartComponent},
{path:"Articals",component:UserArticleComponent},
{path:"articalDetails/:id",component:ArticalDetailsComponent},
{path:"VendorPackages/:id",component:UserPackageComponent},
{path:"BookPackage/:id",component:BookPackageComponent},
{path:"Gallery",component:GalleryComponent}, 
{path:"EditBooks/:id",component:EditBookComponent},                
{path:"",component: UserHomePageComponent,pathMatch:"full"},
   
{path:"**",component:ErrorpageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
