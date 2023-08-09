import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Firestore, doc, DocumentSnapshot, DocumentData, getDoc, updateDoc } from '@angular/fire/firestore';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  title = 'Project_Portofolio';
  userId: string | null = null;
  userData: DocumentData  = {};

  constructor(private route: ActivatedRoute, private firestore: Firestore) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userId = params.get('id');
      if (this.userId) {
        this.getData();
        console.log(this.userId);
        
      }
    });
  }

  async getData() {
    const docRef = doc(this.firestore, `portofolio/${this.userId}`);
    const docSnap: DocumentSnapshot<DocumentData> = await getDoc(docRef);
    if (docSnap.exists()) {
      this.userData = docSnap.data();
    } else {
      console.log('Document not found!');
    }
  }

  async saveData() {
    if (this.userData && this.userId) {
      const docRef = doc(this.firestore, 'portofolio', this.userId);
      await updateDoc(docRef, this.userData);
      console.log('Data updated successfully!');
    }
  }
}

