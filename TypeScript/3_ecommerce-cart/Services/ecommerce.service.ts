
import { Product } from "../models/product.model";
import { CartItem } from "../models/cart-item.model";
import { Category } from "../models/category.enum";

export class ECommerceService {
    private products: Product[] = [
        { id: 1, name: "Laptop", price: 45000, stock: 3, category: Category.Electronics },
        { id: 2, name: "Jeans", price: 1500, stock: 10, category: Category.Clothing },
        { id: 3, name: "Rice Bag", price: 700, stock: 5, category: Category.Grocery }
    ];

    private cart: CartItem[] = [];

    viewProducts(): void {
        console.log("Available Products:");
        for (const p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
        console.log();
    }

    addToCart(productId: number, quantity: number): void {
        const product = this.products.find(p => p.id === productId);
        if (!product) {
            console.log("Product not found.");
            return;
        }

        if (product.stock < quantity) {
            console.log(`Not enough stock for ${product.name}.`);
            return;
        }

        const existingItem = this.cart.find(ci => ci.product.id === productId);
        if (existingItem) {
            existingItem.quantity += quantity;
        } else {
            this.cart.push({ product, quantity });
        }

        product.stock -= quantity;
        console.log(`${quantity} x ${product.name} added to cart.\n`);
    }

    removeFromCart(productId: number): void {
        const index = this.cart.findIndex(ci => ci.product.id === productId);
        if (index === -1) {
            console.log("Product not in cart.");
            return;
        }

        const item = this.cart[index];
        item.product.stock += item.quantity;
        this.cart.splice(index, 1);
        console.log(`${item.product.name} removed from cart.\n`);
    }

    showCartSummary(): void {
        console.log("Cart Summary:");
        let total = 0;
        for (const item of this.cart) {
            const subtotal = item.product.price * item.quantity;
            total += subtotal;
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
        }
        console.log(`Total: ₹${total}`);

        let discountedTotal = total;
        if (total >= 10000) {
            discountedTotal *= 0.85;
        } else if (total >= 5000) {
            discountedTotal *= 0.90;
        }

        if (discountedTotal !== total) {
            console.log(`Discounted Total: ₹${Math.round(discountedTotal)}\n`);
        } else {
            console.log("No discount applied.\n");
        }
    }
}
