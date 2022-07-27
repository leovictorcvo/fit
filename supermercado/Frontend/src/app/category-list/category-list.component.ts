import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Category } from '../models/category';

import {CategoryListService} from '../services/category-list.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.sass']
})
export class CategoryListComponent implements OnInit {
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  activeCategory: string = '';

  list: Category[] = [];

  constructor(private service:CategoryListService) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  async loadCategories() {
    const data = await this.service.getCategories();
      this.list = data;
      this.activeCategory = data[0].id;
      this.change.emit(this.activeCategory);
  }

  handleCategorySelected(categoryId: string) {
    this.activeCategory = categoryId;
    this.change.emit(categoryId);
  }
}
