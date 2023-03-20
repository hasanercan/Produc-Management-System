import { useState, useEffect } from 'react';
import './App.css';
import { Card, Input, Select } from 'antd';

const { Option } = Select;

function App() {
  const [selectedCategoryId, setSelectedCategoryId] = useState('');
  const [products, setProducts] = useState([]);

  useEffect(() => {
    let url = 'https://localhost:7258/Products';
    if (selectedCategoryId !== '') {
      url += `?categoryId=${selectedCategoryId}`;
    }
    fetch(url)
      .then(response => response.json())
      .then(data => setProducts(data.data))
      .catch(error => console.error(error));
  }, [selectedCategoryId]);

  // useEffect(() => {
  //   fetch(`https://localhost:7258//Categories/GetSingleCategoryByIdWithProducts/${categoryId}`)
  //     .then(response => response.json())
  //     .then(data => setProducts(data.data))
  //     .catch(error => console.error(error));
  // }, []);


  // Fiyata göre ürünleri sırala

  const [sortOrder, setSortOrder] = useState('asc'); // asc = artan, desc = azalan

  const handleSortOrderChange = value => {
    setSortOrder(value);
  };

  products.sort((a, b) => {
    const priceA = parseFloat(a.price);
    const priceB = parseFloat(b.price);
    if (sortOrder === 'asc') {
      return priceA - priceB;
    } else {
      return priceB - priceA;
    }
  });

  // Fiyata göre ürünleri sırala


  return (
    <div className="App">
      <div className='header'>
      <Select
        value={selectedCategoryId}
        onChange={(value) => setSelectedCategoryId(value)}
        style={{ width: 200, marginBottom: 16 }}
      >
        <Option value="">All Categories</Option>
        <Option value="1">Category 1</Option>
        <Option value="2">Category 2</Option>
        <Option value="3">Category 3</Option>
      </Select>
        <Select defaultValue="asc" onChange={handleSortOrderChange} style={{ width: 120, marginBottom: 16 }}>
          <Option value="asc">Artan Fiyata Göre</Option>
          <Option value="desc">Azalan Fiyata Göre</Option>
        </Select>
      </div>
      {products.length > 0
  ? products
      .filter(
        (product) =>
          selectedCategoryId === '' || selectedCategoryId === null ||
          product.categoryId === parseInt(selectedCategoryId)
      ).map((product, index) => (
        <Card
          key={index}
          bordered={false}
          style={{
            width: 300,
            marginBottom: 16
          }}
        >
          <p>{product.name}</p>
          <p>Quantity: {product.quantity}</p>
          <p>Unit: {product.unit}</p>
          <p>Price: {product.price}</p>
          <p>Category: {product.categoryId}</p>
          <p>Created Date: {product.createdDate}</p>
        </Card>
      )) : null}
    </div>
  );
}

export default App;
