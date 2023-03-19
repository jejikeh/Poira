import React, {Component} from "react";

class Product {
    constructor(name, defaultQuantity) {
        this.Name = name;
        this.DefaultQuantity = defaultQuantity;
    }
    
    SetName(name){
        this.Name = name;
    }
    
    SetDefaultQuantity(quantity){
        this.DefaultQuantity = quantity;
    }
}

export class CreateProduct extends Component {
    static displayName = CreateProduct.name;
    constructor(props) {
        super(props);
        this.state = {nameProduct: "", quantity: ""}
    }

    submit = e => {
        e.preventDefault()
        fetch('/products', {
            method: 'POST',
            body: JSON.stringify(new Product(this.state.nameProduct, this.state.quantity)),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json())
            .then(res => console.log(res))
    }

    render() {
        return (
            <form onSubmit={this.submit}>
                <input
                    type="text"
                    name="user[name]"
                    value={this.state.nameProduct}
                    onChange={e => this.setState({nameProduct: e.target.value, quantity: this.state.quantity})}
                />
                <br/>
                <input
                    type="text"
                    value={this.state.quantity}
                    onChange={e => this.setState({nameProduct: this.state.nameProduct, quantity: e.target.value})}
                />
                <br/>
                <input type="submit" name="Sign Up" />
            </form>
        );
    }
}