export * from  '../FileUploader/file-upload/file-select.directive';
export * from  '../FileUploader/file-upload/file-drop.directive';
export * from  '../FileUploader/file-upload/file-uploader.class';

import { FileSelectDirective } from '../FileUploader/file-upload/file-select.directive';
import { FileDropDirective } from '../FileUploader/file-upload/file-drop.directive';

export const FILE_UPLOAD_DIRECTIVES:[any] = [FileSelectDirective, FileDropDirective];

export default {
  directives: [
    FILE_UPLOAD_DIRECTIVES
  ]
};
