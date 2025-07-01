import { ECommerceService } from "./services/ecommerce.service";

const service = new ECommerceService();

service.viewProducts();

service.addToCart(1, 1); // Laptop
service.addToCart(2, 2); // Jeans
service.addToCart(3, 1); // Rice Bag

service.removeFromCart(2); // Remove Jeans

service.showCartSummary();
service.viewProducts();
